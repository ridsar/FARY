﻿using UnityEngine;
using System.Collections;

public class targetAttack : MonoBehaviour {

    private float scale;
    public float tooClose;

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
        if(other.tag == "Player" || other.tag == "Crystal")
        {
            transform.GetComponent<SphereCollider>().radius = scale * 2.5f;
            float distance = Vector3.Distance(transform.position, other.transform.position);
            if (distance > tooClose)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * transform.GetComponent<FollowPath>().speed);
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
            transform.GetComponent<SphereCollider>().radius = scale;
            transform.LookAt(transform.GetComponent<FollowPath>().currentTarget);
        }
    }
}
