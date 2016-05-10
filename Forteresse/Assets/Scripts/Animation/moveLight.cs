using UnityEngine;
using System.Collections;

public class moveLight : MonoBehaviour {

    float time = 0;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (time > 100)
            time = 0f;
        time += 1 * Time.deltaTime;
        GetComponent<Light>().intensity = 3 * Mathf.Sin(3f * time) + 5;
    }
}
