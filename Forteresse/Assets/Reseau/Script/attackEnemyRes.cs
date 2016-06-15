﻿using UnityEngine;
using System.Collections;

public class attackEnemyRes : MonoBehaviour
{
    int cpt = 0;

    bool canAttack = true;
    public Animator anim;

    public AudioClip coups;
    AudioSource audio;

    float time = 0;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        audio.clip = coups;
       // StartCoroutine(autoAttack());
    }

    // Update is called once per frame
    void Update()
    {
        if (cpt == -1)
        {
            GameObject dmg = transform.GetChild(0).gameObject;

            anim.SetBool("attack", false);
            dmg.GetComponent<BoxCollider>().enabled = false;
            canAttack = true;
            cpt = 0;
        }
        if (time >= 0)
            time -= 1 * Time.deltaTime;

        canAttack = false;
        if (GetComponent<targetAttackRes>().target != null)
        {
            if (Vector3.Distance(transform.position, GetComponent<targetAttackRes>().target.transform.position) < GetComponent<targetAttackRes>().tooClose + 2)
            {
                canAttack = true;
            }
        }
        if (canAttack)
        {
            if (time < 0)
            {
                time = 2f;
                StartCoroutine(autoAttack());
                cpt = -1;
            }
        }
    }
    /*void OnTriggerEnter(Collider other)
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
    }*/

    IEnumerator autoAttack()
    {

        GameObject dmg = transform.GetChild(0).gameObject;
        dmg.GetComponent<BoxCollider>().enabled = true;
        //Anim attaque
        anim.SetBool("attack", true);
        audio.Play();
        yield return new WaitForSeconds(0);
    }
}
