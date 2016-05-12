using UnityEngine;
using System.Collections;

public class attackEnemyCaster : MonoBehaviour
{

    bool canAttack = true;
    Vector3 scale;

    // Use this for initialization
    void Start()
    {
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Crystal")
        {
            if (canAttack)
            {
                canAttack = false;
                StartCoroutine(autoAttack());
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
    }
    IEnumerator autoAttack()
    {
        GameObject dmg = transform.GetChild(0).gameObject;
        while (!canAttack)
        {
            Vector3 pos = new Vector3(transform.position.x, 7f, transform.position.z);
            Quaternion rot = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);

            var arrow = Instantiate(dmg, pos, rot) as GameObject; //Créer la fleche

            arrow.SetActive(true);
            arrow.transform.localScale = scale;
            arrow.name = dmg.name + "(Clone)"; 

            CancelInvoke();
            GameObject.Find("Arrow(Clone)").GetComponent<selfDestruct>().enabled = true;
            GameObject.Find("Arrow(Clone)").name = "Arrow(Build)";

            canAttack = true;

            yield return new WaitForSeconds(1.5f);
        }
    }
}
