using UnityEngine;
using System.Collections;

public class targetAttack : MonoBehaviour
{

    int n;

    private float scale;
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

    Transform parent_;

	// Use this for initialization
	void Start ()
    {
        time = 0.3f;
        parent_ = transform.parent;
        if (transform.name == "Ranger")
            bonus = 1.5f;

        switch (parent_.name[1])
        {
            case 'S':
                scale = 7.5f * parent_.localScale.x;
                break;
            case 'G':
                scale = 1.5f * parent_.localScale.x;
                break;
            case 'T':
                scale = 0.25f * parent_.localScale.x;
                break;
            case 'R':
                scale = 2f * parent_.localScale.x;
                break;
            case 'H':
                scale = 1.75f * parent_.localScale.x;
                break;
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
            foreach (Collider other in Physics.OverlapSphere(transform.position, scale))
            {
                if (other.tag == "Player")
                {
                    target = other.gameObject;
                    isFollowing = true;
                    n = 0;
                }
                else if (other.tag == "Crystal")
                {
                    target = other.gameObject;
                    isFollowing = true;
                    n = 1;
                }
            }
        }

        

        if (target != null)
        {
            if (Vector3.Distance(parent_.position, target.transform.position) > scale * 2.5f)
            {
                target = null;
                return;
            }
            if (n == 0)
            {
                float distance = Vector3.Distance(parent_.position, target.transform.position);
                if (distance > tooClose)
                {
                    parent_.Translate(Vector3.forward * Time.deltaTime * (parent_.GetComponent<FollowPath>().speed));
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
                parent_.LookAt(newPos);
                parent_.GetComponent<FollowPath>().enabled = false;
            }       
            else if (n == 1)
            {
                float distance = Vector3.Distance(parent_.position, target.transform.position);

                Vector3 newPos = new Vector3(target.transform.position.x, parent_.position.y, target.transform.position.z);
                parent_.LookAt(newPos);
                parent_.GetComponent<FollowPath>().enabled = false;
            }    
        }
        else
        {
            parent_.GetComponent<FollowPath>().enabled = true;

            parent_.LookAt(parent_.GetComponent<FollowPath>().currentTarget);
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
