using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {

    public GameObject enemies;
    public int amount = 0;
    public float spawingTime;
    public int enemyNumber;
    public int waveNb = 1;

    public List<string> myWave = new List<string>();

    public bool check = false;
    private Vector3 spawnPoints;

    void Start()
    {
        
    }

    void Update ()
    {
        if (Input.GetKey(KeyCode.F) && !check)
        {
            switch (waveNb)
            {
                case 1:
                    switch (name)
                    {
                        case "A":
                            spawingTime = 1;
                            enemyNumber = 6;
                            myWave.Add("Troll"); myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy");
                            myWave.Add("Enemy");
                            break;
                        case "B":
                            spawingTime = 3;
                            enemyNumber = 0;
                            break;
                        case "C":
                            spawingTime = 10;
                            enemyNumber = 0;
                            break;
                        case "D":
                            spawingTime = 2;
                            enemyNumber = 0;
                            break;
                        case "E":
                            spawingTime = 2.5f;
                            enemyNumber = 0;
                            break;
                    }
                    break;
                case 2:
                    switch (name)
                    {
                        case "A":
                            spawingTime = 1;
                            enemyNumber = 10;
                            myWave.Add("Troll"); myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy");
                            myWave.Add("Enemy"); myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy");
                            break;
                        case "B":
                            spawingTime = 3;
                            enemyNumber = 3;
                            myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Enemy");
                            break;
                        case "C":
                            spawingTime = 10;
                            enemyNumber = 1;
                            myWave.Add("Troll");
                            break;
                        case "D":
                            spawingTime = 2;
                            enemyNumber = 5;
                            myWave.Add("Troll"); myWave.Add("Enemy"); myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Enemy");
                            break;
                        case "E":
                            spawingTime = 2.5f;
                            enemyNumber = 0;
                            break;
                    }
                    break;

                case 3:
                    switch (name)
                    {
                        case "A":
                            spawingTime = 1;
                            enemyNumber = 20;
                            myWave.Add("Troll"); myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy");
                            myWave.Add("Enemy"); myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy");
                            myWave.Add("Enemy"); myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy");
                            myWave.Add("Enemy"); myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy");
                            break;
                        case "B":
                            spawingTime = 3;
                            enemyNumber = 3;
                            myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Enemy");
                            break;
                        case "C":
                            spawingTime = 10;
                            enemyNumber = 5;
                            myWave.Add("Troll"); myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy");
                            break;
                        case "D":
                            spawingTime = 2;
                            enemyNumber = 10;
                            myWave.Add("Troll"); myWave.Add("Enemy"); myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Enemy");
                            myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Goblin"); myWave.Add("Enemy");
                            break;
                        case "E":
                            spawingTime = 2.5f;
                            enemyNumber = 4;
                            myWave.Add("Troll"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy");
                            break;
                    }
                    break;
            }
            ++waveNb;
            check = true;
        }
        else if (check && transform.parent.GetComponent<Wave>().check)
        {
            check = false;
            transform.parent.GetComponent<Wave>().check = false;
            print("hello");
        }
        if (amount != enemyNumber && check)
        {
            InvokeRepeating("spawnEnemy", spawingTime, 10f);
        }
	}

    void spawnEnemy()
    {
        spawnPoints.x = Random.Range(-20 + transform.position.x, 20 + transform.position.x);
        spawnPoints.y = 0.5f;
        spawnPoints.z = Random.Range(-20 + transform.position.z, 20 + transform.position.z);

        Instantiate(GameObject.Find(myWave[amount]), spawnPoints, Quaternion.identity).name = gameObject.name + myWave[amount] + "(Clone)";
        /*if(myWave.Capacity > 0)
            myWave.RemoveAt(0);*/
        ++amount;
        CancelInvoke();
    }
}
