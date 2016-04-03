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
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
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
        if (other.tag == "Player")
        {
            canAttack = canAttack && false;
        }
        else
            canAttack = canAttack && true;
    }
    void OnTriggerExit (Collider other)
    {
        if (other.tag == "Player")
        {
            canAttack = true;
        }
    }
    IEnumerator autoAttack()
    {
        GameObject dmg  = transform.GetChild(0).gameObject;
        while (!canAttack)
        {
            dmg.GetComponent<BoxCollider>().enabled = true;
            print("attaque");
            yield return new WaitForSeconds(0.5f);
            dmg.GetComponent<BoxCollider>().enabled = false;
            canAttack = true;
            yield return new WaitForSeconds(2f);
        }
    }
}
