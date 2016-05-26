using UnityEngine;
using System.Collections;

public class shieldFade : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(transform.parent.GetComponent<enemyHealth>().playerHealth < 100)
        {
            gameObject.SetActive(false);
        }
	}
}
