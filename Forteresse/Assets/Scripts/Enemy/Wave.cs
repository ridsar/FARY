using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        GameObject.FindGameObjectWithTag("Spawn").SetActive(false);
    }
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (GameObject.FindGameObjectWithTag("Spawn"))
            {
                GameObject.FindGameObjectWithTag("Spawn").SetActive(true);
                print("hello it's me");
            }
        }
    }
}
