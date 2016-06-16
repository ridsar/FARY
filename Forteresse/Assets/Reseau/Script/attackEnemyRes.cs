using UnityEngine;
using System.Collections;

public class attackEnemyRes : MonoBehaviour
{
    int cpt = 0;
    float enemyAttackSpeed;

    public bool canAttack = true;
    public Animator anim;
    public bool animatored;


    public AnimationClip cool;
    public AnimationClip marche;

    public AudioClip coups;
    AudioSource audio;

    float time = 0;

    // Use this for initialization
    void Start()
    {
        if (name.Contains("S"))
            enemyAttackSpeed = 1f;
        else if (name.Contains("G"))
            enemyAttackSpeed = 0.7f;
        else if (name.Contains("T"))
            enemyAttackSpeed = 1.5f;
        else if (name.Contains("R"))
            enemyAttackSpeed = 2f;
        else if (name.Contains("H"))
            enemyAttackSpeed = 2f;


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
        if (cpt == -1)
        {
            GameObject dmg = transform.GetChild(0).gameObject;

            if (animatored)
                anim.SetBool("attack", false);
            else
                GetComponent<Animation>().Play(cool.name);

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
                time = enemyAttackSpeed;
                StartCoroutine(autoAttack());
                cpt = -1;
            }
        }
    }

    IEnumerator autoAttack()
    {

        GameObject dmg = transform.GetChild(0).gameObject;
        dmg.GetComponent<BoxCollider>().enabled = true;
        //Anim attaque
        if (animatored)
        {
            anim.SetBool("cool", true);
            anim.SetBool("attack", true);
        }
        else
            GetComponent<Animation>().Play(marche.name);

        audio.Play();
        yield return new WaitForSeconds(0);
    }
}
