using UnityEngine;
using System.Collections;

public class FireEnemyAttackRes : MonoBehaviour
{


    public GameObject fire;
    bool canAttack = false;
    float time = 0f;
    GameObject firebreath;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
            time -= 1 * Time.deltaTime;

        if (time <= 0 && GetComponent<attackEnemyRes>().canAttack)
        {
            firebreath = Instantiate(fire) as GameObject;
            firebreath.transform.parent = transform;
            firebreath.transform.localPosition = new Vector3(0f, 2.30f, 0.8f);
            firebreath.transform.localRotation = new Quaternion(330f, -180, 0, 0);
            firebreath.SetActive(true);
            StartCoroutine(Fire());

            time = 5f;
        }
    }
    /*void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Crystal")
        {
            if (canAttack)
            {
                canAttack = false;
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Crystal")
        {
            canAttack = canAttack && false;
        }
        else
            canAttack = canAttack && true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Crystal")
        {
            canAttack = true;
        }
    }*/
    IEnumerator Fire()
    {
        transform.FindChild("fireBreath dmg").GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(1f);
        transform.FindChild("fireBreath dmg").GetComponent<BoxCollider>().enabled = false;
    }
}
