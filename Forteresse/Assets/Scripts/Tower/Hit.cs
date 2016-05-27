using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other is CapsuleCollider || other.tag == "Shield")
        {
            if (other.tag == "Enemy" || other.tag == "Shield")
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
