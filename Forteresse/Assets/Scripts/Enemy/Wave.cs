using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {


    // Use this for initialization
    void Start()
    {
        if(GameObject.Find("spawn"))
            GameObject.Find("spawn").SetActive(false);
    }
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.F))
            GameObject.Find("spawn").SetActive(true);
	}
}
