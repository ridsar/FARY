using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {



    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        RaycastHit hit;
        Vector3 p1 = transform.position;
        float distance = 0f;

        if(Physics.SphereCast(p1, 10f, transform.forward, out hit, 10f))
        {
            distance = hit.distance;
            print(distance);
        }
	}
}
