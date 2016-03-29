using UnityEngine;
using System.Collections;

public class targetAttack : MonoBehaviour {

    private Vector3 direction;
    private float scale;

	// Use this for initialization
	void Start ()
    {
        scale = transform.GetComponent<SphereCollider>().radius;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            transform.GetComponent<SphereCollider>().radius = scale * 2f;
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
        if(other.tag == "Player")
        {
            GetComponent<FollowPath>().enabled = true;
            transform.GetComponent<SphereCollider>().radius = scale;
        }
    }
}
