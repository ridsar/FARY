using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {
    GameObject spawn;
    public bool check;
    int compte = 0;
    Spawn spawnScript;
    

    // Use this for initialization
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        foreach(Transform obj in gameObject.transform)
        {
            compte += obj.GetComponent<Spawn>().myWave.Capacity;
        }
        if (compte == 0 && Input.GetKey(KeyCode.F))
        {
            check = true;
            print("new wave");
            //GetComponent<Spawn>().waveNb += 1;
            GetComponent<Spawn>().amount = 0;
            GetComponent<Spawn>().check = false;
        }
    }  
}
