using UnityEngine;
using UnityEngine;
using System.Collections;

public class AttackEnemyCasterRes : MonoBehaviour
{

    bool canAttack;
    Vector3 scale;
    float time = 1.5f;


    public AudioClip coups;
    AudioSource audio;

    //public Animator anim;

    // Use this for initialization
    void Start()
    {
        canAttack = true;
        scale = Vector3.one;

        audio = GetComponent<AudioSource>();
        audio.clip = coups;
    }

    // Update is called once per frame
    void Update()
    {
        //Timer
        if (time >= 0)
            time -= 1 * Time.deltaTime;

        //Deteremine si il doit y avior attaque
        canAttack = false;
        if (GetComponent<targetAttackRes>().target != null)
        {
            if (Vector3.Distance(transform.position, GetComponent<targetAttackRes>().target.transform.position) < GetComponent<targetAttackRes>().tooClose + 2)
            {
                canAttack = true;
            }
        }

        //L'attaque
        if (canAttack)
        {
            if (time < 0)
            {
                time = 1.5f;

                audio.Play();
                GameObject dmg = transform.GetChild(0).gameObject;

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
            }
        }
    }
}
