using UnityEngine;
using System.Collections;

public class attackEnemyCaster : MonoBehaviour
{

    bool canAttack;
    Vector3 scale;
    float time = 1.5f;

    public Animator anim;

    // Use this for initialization
    void Start()
    {
        canAttack = true;
        scale = Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
            time -= 1 * Time.deltaTime;
        else
            time = 0;
        if(!canAttack && time == 0)
        {
            anim.SetBool("arrow", true);
            GameObject dmg = transform.GetChild(0).gameObject;
            //double cosAngle = Mathf.Cos(transform.eulerAngles.y * Mathf.PI / 180);
            double sinAngle = Mathf.Sin(transform.eulerAngles.y * Mathf.PI / 180);

            Vector3 pos = new Vector3(0, 1f, 1.5f);
            Quaternion rot = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);

            GameObject arrow = Instantiate(dmg, pos, rot) as GameObject; //Créer la fleche
            CancelInvoke();
            arrow.transform.parent = transform;
            arrow.transform.localPosition = pos;
            arrow.SetActive(true);
            arrow.transform.localScale = scale;
            arrow.name = dmg.name + "(Clone)";

            GameObject.Find("Arrow(Clone)").GetComponent<selfDestruct>().enabled = true;
            GameObject.Find("Arrow(Clone)").GetComponent<moveForward>().enabled = true;
            GameObject.Find("Arrow(Clone)").name = "Arrow(Build)";

            time = 1.5f;
        }
        else
        {
            anim.SetBool("arrow", false);
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
    void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player" || other.tag == "Crystal") && canAttack)
        {
            canAttack = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Crystal")
        {
            canAttack = true;
        }
    }   
}
