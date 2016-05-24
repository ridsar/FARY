using UnityEngine;
using System.Collections;

public class attackEnemy : MonoBehaviour {


    bool canAttack = true;
    public Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
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
    void OnTriggerExit (Collider other)
    {
        if (other.tag == "Player" || other.tag == "Crystal")
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
            //Anim attaque
            anim.SetBool("attack", true);
            yield return new WaitForSeconds(0.5f);
            anim.SetBool("attack", false);
            dmg.GetComponent<BoxCollider>().enabled = false;
            canAttack = true;
            yield return new WaitForSeconds(2f);
        }
    }
}
