using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {
    public bool check;
    public int enemyNumber;
    public int compte = 0;
    

    // Use this for initialization
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        compte = 0;
        enemyNumber = 0;

        foreach (Transform obj in gameObject.transform) //regarde si il reste des enemies a pop ou a tuer
        {
            compte += obj.GetComponent<Spawn>().myWave.Count;
            enemyNumber += obj.GetComponent<Spawn>().myEnemy.Count;
        }

        //Le nombre d'enemie restant a invoquer doit etre nul ainsi que le nombre d'enemie en vie. On doit appuyer sur 'F'
        if (Input.GetKey(KeyCode.F) && compte == 0 && enemyNumber == 0)
        {
            check = true; //sert dans le script 'Spawn'
            print("new wave"); //indicatif just pour test
            foreach (Transform obj in gameObject.transform) //va du gameobject 'A' au 'E' dans le gameobject 'Spawn'
            {
                obj.GetComponent<Spawn>().check = false; //met le 'check' du script Spawn sur 'false'
            }
        }
    }  
}
