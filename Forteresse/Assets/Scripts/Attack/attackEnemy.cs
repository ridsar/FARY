using UnityEngine;
using System.Collections;

public class attackEnemy : MonoBehaviour {


    bool canAttack = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            float dist = Vector3.Distance(transform.position, other.transform.position);
            if (dist < 10f && canAttack)
            {
                StartCoroutine(autoAttack());
                canAttack = false;
            }
            else if (dist >= 10f)
            {
                StopCoroutine(autoAttack());
                canAttack = true;
            }
        }
    }
    IEnumerator autoAttack()
    {
        if (!canAttack)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
            print("attaque");
            gameObject.GetComponent<BoxCollider>().enabled = false;
            print("fin");
            yield return new WaitForSeconds(3f);

        }
    }
}
