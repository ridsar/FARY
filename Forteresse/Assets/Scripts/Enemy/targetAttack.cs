using UnityEngine;
using System.Collections;

public class targetAttack : MonoBehaviour {

    private float scale;
    public float tooClose;

    float bonus = 1;
    Transform parent_;

	// Use this for initialization
	void Start ()
    {
        parent_ = transform.parent;
        scale = GetComponent<SphereCollider>().radius;
        if (transform.name == "Ranger")
            bonus = 1.5f;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            transform.GetComponent<SphereCollider>().radius = scale * 2.5f;
            float distance = Vector3.Distance(parent_.position, other.transform.position);
            if (distance > tooClose)
            {
                parent_.Translate(Vector3.forward * Time.deltaTime * parent_.GetComponent<FollowPath>().speed);
            }
            Vector3 newPos = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
            parent_.LookAt(newPos);
            parent_.GetComponent<FollowPath>().enabled = false;
        }
        else if(other.tag == "Crystal")
        {
            transform.GetComponent<SphereCollider>().radius = scale * 2.5f;
            float distance = Vector3.Distance(transform.position, other.transform.position);
            if (distance > tooClose * 2 / bonus)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * parent_.GetComponent<FollowPath>().speed);
            }
            Vector3 newPos = new Vector3(other.transform.position.x, parent_.position.y, other.transform.position.z);
            parent_.LookAt(newPos);
            parent_.GetComponent<FollowPath>().enabled = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player" || other.tag == "Crystal")
        {
            parent_.GetComponent<FollowPath>().enabled = true;
            transform.GetComponent<SphereCollider>().radius = scale;
            parent_.LookAt(parent_.GetComponent<FollowPath>().currentTarget);
        }
    }
}
