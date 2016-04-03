using UnityEngine;
using System.Collections;

public class attackEnemy : MonoBehaviour {


    bool canAttack = true;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(autoAttack());
    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack)
        {
            canAttack = false;
            StartCoroutine(autoAttack());
        }

    }
    void OnTriggerEnter(Collider other)
    {

    }
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            float dist = Vector3.Distance(transform.position, other.transform.position);
            if (dist < 10f && canAttack)
            {
                gameObject.GetComponent<BoxCollider>().enabled = true;
                canAttack = false;
            }
            else
            {
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
    IEnumerator autoAttack()
    {
        while (!canAttack)
        {
            gameObject.GetComponent<BoxCollider>().enabled = !canAttack;
            print("attaque");
            yield return new WaitForSeconds(2f);
        }

    }
}
