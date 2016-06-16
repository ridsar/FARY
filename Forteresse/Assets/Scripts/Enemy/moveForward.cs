using UnityEngine;
using System.Collections;

public class moveForward : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 100);
    }
    void OnTriggerEnter(Collider other)
    {
        print(other.gameObject);
        if(other.tag == "Crystal" || other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
