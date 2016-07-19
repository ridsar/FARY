using UnityEngine;
using System.Collections;

public class targetAttack : MonoBehaviour
{

    int n;

    private float scale;
    private float saveTooClose;
    private float fromTheCrystal;
    public float tooClose;
    float bonus = 1;
    float time;

    public GameObject perso;
    public GameObject target;

    public AnimationClip cool;
    public AnimationClip marche;
    public Animator anim;

    bool isFollowing;
    public bool animatored;

	// Use this for initialization
	void Start ()
    {
        saveTooClose = tooClose;
        time = 0.3f;

        if (transform.name == "Ranger")
            bonus = 1.5f;

        if (name.Contains("S"))
        {
            scale = 7.5f * transform.localScale.x;
            fromTheCrystal = 3f;
        }
        else if (name.Contains("G"))
        {
            scale = 1.5f * transform.localScale.x;
            fromTheCrystal = 3.5f;
        }
        else if (name.Contains("T"))
        {
            scale = 0.25f * transform.localScale.x;
            fromTheCrystal = 1.8f;
        }
        else if (name.Contains("R"))
        {
            scale = 5f * transform.localScale.x;
            fromTheCrystal = 3f;
        }
        else if (name.Contains("H"))
        {
            scale = 1.75f * transform.localScale.x;
            fromTheCrystal = 1.8f;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        isFollowing = false;
        if (target == null && time > 0)
            time -= 1 * Time.deltaTime;

        if (target == null && time < 0)
        {
                time = 0.3f;
            foreach (Collider other in Physics.OverlapSphere(transform.position, scale * 2))
            {
                if (other.tag == "Player" && Vector3.Distance(transform.position, other.transform.position) < scale)
                {
                    tooClose = saveTooClose;
                    target = other.gameObject;
                    isFollowing = true;
                    n = 0;
                }
                else if (other.tag == "Crystal")
                {
                    tooClose = saveTooClose * fromTheCrystal;
                    target = other.gameObject;
                    isFollowing = true;
                    n = 1;
                }
            }
        }

        

        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);

            if (Vector3.Distance(transform.position, target.transform.position) > scale * 2.5f)
            {
                target = null;
                return;
            }
            if (n == 0)
            {
                if (distance > tooClose)
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * (transform.GetComponent<FollowPath>().speed));
                    if (animatored)
                    {
                        anim.SetBool("cool", false);
                    }
                    else
                    {
                        perso.GetComponent<Animation>().Play(marche.name);
                    }
                }
                else
                {
                    if (animatored)
                    {
                        anim.SetBool("cool", true);
                    }
                    else
                    {
                        perso.GetComponent<Animation>().Play(cool.name);
                    }
                }
                Vector3 newPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
                transform.LookAt(newPos);
                transform.GetComponent<FollowPath>().enabled = false;
            }       
            else if (n == 1)
            {

                if (distance > tooClose)
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * (transform.GetComponent<FollowPath>().speed));
                }

                Vector3 newPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
                transform.LookAt(newPos);
                transform.GetComponent<FollowPath>().enabled = false;
            }    
        }
        else
        {
            transform.GetComponent<FollowPath>().enabled = true;

            transform.LookAt(transform.GetComponent<FollowPath>().currentTarget);
        }
    }






    /*void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            transform.GetComponent<SphereCollider>().radius = scale * 2.5f;
            float distance = Vector3.Distance(parent_.position, other.transform.position);
            if (distance > tooClose)
            {
                parent_.Translate(Vector3.forward * Time.deltaTime * (parent_.GetComponent<FollowPathRes>().speed / 2 ));
                if (animatored)
                {
                    anim.SetBool("cool", false);
                }
                else
                {
                    perso.GetComponent<Animation>().Play(marche.name);
                }
            }
            else
            {
                if (animatored)
                {
                    anim.SetBool("cool", true);
                }
                else
                {
                    perso.GetComponent<Animation>().Play(cool.name);
                }
            }
            Vector3 newPos = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
            parent_.LookAt(newPos);
            parent_.GetComponent<FollowPathRes>().enabled = false;
        }


        else if(other.tag == "Crystal")
        {
            transform.GetComponent<SphereCollider>().radius = scale * 2.5f;
            float distance = Vector3.Distance(parent_.position, other.transform.position);
            if (distance > tooClose * 2 / bonus)
            {
                //transform.Translate(Vector3.forward * Time.deltaTime * parent_.GetComponent<FollowPath>().speed);
            }
            Vector3 newPos = new Vector3(other.transform.position.x, parent_.position.y, other.transform.position.z);
            parent_.LookAt(newPos);
            parent_.GetComponent<FollowPathRes>().enabled = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player" || other.tag == "Crystal")
        {
            parent_.GetComponent<FollowPathRes>().enabled = true;
            transform.GetComponent<SphereCollider>().radius = scale;
            parent_.LookAt(parent_.GetComponent<FollowPathRes>().currentTarget);
        }
    }*/
}
