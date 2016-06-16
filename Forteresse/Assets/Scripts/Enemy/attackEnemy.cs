using UnityEngine;
using System.Collections;

public class attackEnemy : MonoBehaviour {


    bool canAttack = true;
    public Animator anim;
    public bool animatored;

    public AnimationClip cool;
    public AnimationClip marche;

    public AudioClip coups;
    AudioSource audio;

    // Use this for initialization
    void Start()
    {
        if (animatored)
        {
            anim = GetComponent<Animator>();
        }
        audio = GetComponent<AudioSource>();
        audio.clip = coups;
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
            if (animatored)
            {
                anim.SetBool("cool", true);
                anim.SetBool("attack", true);
            }
            else
            {
                GetComponent<Animation>().Play(marche.name);
            }

            audio.Play();
            yield return new WaitForSeconds(0.5f);
            if (animatored)
            {
                anim.SetBool("attack", false);
            }
            else
            {
                GetComponent<Animation>().Play(cool.name);
            }
            dmg.GetComponent<BoxCollider>().enabled = false;
            canAttack = true;
            yield return new WaitForSeconds(2f);
        }
    }
}
