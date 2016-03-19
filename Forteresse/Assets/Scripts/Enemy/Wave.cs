using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {
    GameObject spawn;
    bool check = true;
    Spawn spawnScript;
    

    // Use this for initialization
    void Start()
    {
        
    }
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (check)
                GetComponent<Spawn>().enabled = true;
            else
            {
                GetComponent<Spawn>().enabled = false;
            }
            check = !check;

        }
    }
}
