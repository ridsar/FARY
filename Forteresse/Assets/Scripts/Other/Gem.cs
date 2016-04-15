using UnityEngine;
using System.Collections;

public class Gem : MonoBehaviour
{
    public float speed = 0;


	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        speed += 1.5f * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, 10 + 1.5f * Mathf.Sin(speed), transform.position.z);
    }
}
