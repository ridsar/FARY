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
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        altitude_down += 1 * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, 10 + Mathf.Sin(altitude_down), transform.position.z);
    }
}
