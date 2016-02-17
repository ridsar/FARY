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
        if (transform.position.y < 10)
            rb.AddForce(0, 20, 0);
        /*if (transform.position.y >= altitude_up)
            transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
        if (transform.position.y <= altitude_down)
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;*/
    }
}
