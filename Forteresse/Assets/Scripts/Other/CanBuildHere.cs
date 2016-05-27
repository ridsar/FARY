﻿using UnityEngine;
using System.Collections;

public class CanBuildHere : MonoBehaviour {

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
        if (gameObject.GetComponent<CanBuildHere>().isActiveAndEnabled == true)
        {           
            Physics.IgnoreCollision(gameObject.GetComponent<SphereCollider>(), other);

            if (other.tag == "NoBuild")
            {
                transform.GetChild(1).GetComponent<MeshRenderer>().material.color = new Color(1.0f, 0.2f, 0.2f, 1.0f);
                GameObject.Find("Player").GetComponent<Build>().isBuildable = false;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(gameObject.GetComponent<CanBuildHere>().isActiveAndEnabled == true)
        {
            if (other.tag == "NoBuild")
            {
                transform.GetChild(1).GetComponent<MeshRenderer>().material.color = new Color(0.2f, 1.0f, 0.2f, 1.0f);
                GameObject.Find("Player").GetComponent<Build>().isBuildable = true;
            }
        }
    }
}
