using UnityEngine;
using System.Collections;

public class moveForward : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 100);
        Physics.IgnoreCollision(gameObject.GetComponent<BoxCollider>(), GetComponentInParent<Collider>());
    }
    void OnCollisionEnter(Collision other)
    {
        
        if (other.transform.tag == "Player")
            Destroy(gameObject);
    }
    /*void OnCollisionStay(Collision other)
    {
        if (other.transform.tag == "Enemy")
            Physics.IgnoreCollision(gameObject.GetComponent<BoxCollider>(), other.collider);
    }*/
}
