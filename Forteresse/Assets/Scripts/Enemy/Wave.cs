using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {
    GameObject spawn;
    public bool check;
    public int compte = 0;
    Spawn spawnScript;
    

    // Use this for initialization
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        compte = 0;

        foreach(Transform obj in gameObject.transform)
        {
            compte += obj.GetComponent<Spawn>().myWave.Count;
        }
        if (compte == 0 && Input.GetKey(KeyCode.F))
        {
            check = true;
            print("new wave");
            foreach (Transform obj in gameObject.transform)
            {
                obj.GetComponent<Spawn>().check = false;
            }
        }
    }  
}
