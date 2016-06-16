using UnityEngine;
using System.Collections;

public class attackEnemy : MonoBehaviour {

    float time;
    int cpt;

    public bool canAttack = true;
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
        if (GetComponent<targetAttack>().target != null)
        {
            if (Vector3.Distance(transform.position, GetComponent<targetAttack>().target.transform.position) < GetComponent<targetAttack>().tooClose + 2)
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
