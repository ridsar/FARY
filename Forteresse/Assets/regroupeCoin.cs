using UnityEngine;
using System.Collections;

public class regroupeCoin : MonoBehaviour {

    int n = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerStay(Collider other)
    {
        if(n == 10)
        {

        }
        if(other.tag == "Money")
        {
            ++n;
        }
    }
}
