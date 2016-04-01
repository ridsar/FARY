using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag != "Field" && other.transform.tag != "Player")
            Physics.IgnoreCollision(gameObject.GetComponent<SphereCollider>(), other.collider);
    }
}
