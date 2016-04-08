using UnityEngine;
using System.Collections;

public class Gem : MonoBehaviour {
    public float speed = 0.5f;
    public float altitude_up = 1;
    public float altitude_down = 10;
    Rigidbody rb;


	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        rb.AddForce(1000, 0, 1000);
    }
}
