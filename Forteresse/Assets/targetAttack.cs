using UnityEngine;
using System.Collections;

public class targetAttack : MonoBehaviour {

    Vector3 direction;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" || other.tag == "Crystal")
        {
            transform.GetComponent<SphereCollider>().radius = 15f;
            float distance = Vector3.Distance(transform.position, other.transform.position);
            if (distance > 7)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * 20);
            }
            transform.LookAt(other.transform);
            GetComponent<FollowPath>().enabled = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player" || other.tag == "Crystal")
        {
            GetComponent<FollowPath>().enabled = true;
            transform.GetComponent<SphereCollider>().radius = 7f;
        }
    }
}
