using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {
    GameObject spawn;
    public bool check = true;
    Spawn spawnScript;
    

    // Use this for initialization
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        foreach(Transform obj in gameObject.transform.parent)
        {
            check = check && obj.GetComponent<Spawn>().enabled == false;
        }
        if (check && Input.GetKey(KeyCode.F))
        {
            GetComponent<Spawn>().enabled = true;
        }
    }  
}
