using UnityEngine;
using System.Collections;

public class attackEnemyCaster : MonoBehaviour
{

    bool canAttack = true;
    Vector3 scale;
    bool start = true;

    // Use this for initialization
    void Start()
    {
        scale = Vector3.one;
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
                if (start)
                {
                    start = false;
                    StartCoroutine(autoAttack());
                }
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
            //double cosAngle = Mathf.Cos(transform.eulerAngles.y * Mathf.PI / 180);
            double sinAngle = Mathf.Sin(transform.eulerAngles.y * Mathf.PI / 180);

            Vector3 pos = new Vector3(transform.position.x, 7f, transform.position.z);
            Quaternion rot = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);

            var arrow = Instantiate(dmg, pos, rot) as GameObject; //Créer la fleche
            CancelInvoke();
            arrow.transform.position = pos;
            arrow.transform.parent = transform;
            arrow.SetActive(true);
            arrow.transform.localScale = scale;
            arrow.name = dmg.name + "(Clone)"; 

            GameObject.Find("Arrow(Clone)").GetComponent<selfDestruct>().enabled = true;
            GameObject.Find("Arrow(Clone)").GetComponent<moveForward>().enabled = true;
            GameObject.Find("Arrow(Clone)").name = "Arrow(Build)";

            yield return new WaitForSeconds(1.5f);
        }
    }
}
