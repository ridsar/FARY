using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

    private Transform target = null;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (target == null)
            return;
        else
            transform.LookAt(target);

    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy" && target == null)
            target = other.transform;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            target = null;
        }
    }
}
