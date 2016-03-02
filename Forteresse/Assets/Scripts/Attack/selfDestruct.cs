using UnityEngine;
using System.Collections;

public class selfDestruct : MonoBehaviour {

    public int sec;
	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, sec);   
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
