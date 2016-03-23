using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {

    public GameObject enemies;
    public float spawingTime;
    public int enemyNumber;
    public int waveNb = 1;

    public List<string> myWave = new List<string>();
    public List<GameObject> myEnemy = new List<GameObject>();

    public bool check = false;
    private Vector3 spawnPoints;

    void Start()
    {
        
    }

    void Update ()
    {
        if (Input.GetKey(KeyCode.F) && !check)
        {
            print(name);
            switch (waveNb)
            {
                case 1:
                    switch (name)
                    {
                        case "A":
                            spawingTime = 1;
                            myWave.Add("Troll"); myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy");
                            myWave.Add("Enemy");
                            break;
                        case "B":
                            spawingTime = 3;
                            break;
                        case "C":
                            spawingTime = 10;
                            break;
                        case "D":
                            spawingTime = 2;
                            break;
                        case "E":
                            spawingTime = 2.5f;
                            break;
                    }
                    break;
                case 2:
                    switch (name)
                    {
                        case "A":
                            spawingTime = 1;
                            myWave.Add("Troll"); myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy");
                            myWave.Add("Enemy"); myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy");
                            break;
                        case "B":
                            spawingTime = 3;
                            myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Enemy");
                            break;
                        case "C":
                            spawingTime = 10;
                            myWave.Add("Troll");
                            break;
                        case "D":
                            spawingTime = 2;
                            myWave.Add("Troll"); myWave.Add("Enemy"); myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Enemy");
                            break;
                        case "E":
                            spawingTime = 2.5f;
                            break;
                    }
                    break;

                case 3:
                    switch (name)
                    {
                        case "A":
                            spawingTime = 1;
                            myWave.Add("Troll"); myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy");
                            myWave.Add("Enemy"); myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy");
                            myWave.Add("Enemy"); myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy");
                            myWave.Add("Enemy"); myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy");
                            break;
                        case "B":
                            spawingTime = 3;
                            myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Enemy");
                            break;
                        case "C":
                            spawingTime = 10;
                            myWave.Add("Troll"); myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy");
                            break;
                        case "D":
                            spawingTime = 2;
                            myWave.Add("Troll"); myWave.Add("Enemy"); myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Enemy");
                            myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Goblin"); myWave.Add("Enemy");
                            break;
                        case "E":
                            spawingTime = 2.5f;
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
        }
        if (myWave.Count > 0 && check)
        {
            InvokeRepeating("spawnEnemy", spawingTime, 10f);
        }
	}

    void spawnEnemy()
    {
        spawnPoints.x = Random.Range(-20 + transform.position.x, 20 + transform.position.x);
        spawnPoints.y = 0.5f;
        spawnPoints.z = Random.Range(-20 + transform.position.z, 20 + transform.position.z);

        Instantiate(GameObject.Find(myWave[0]), spawnPoints, Quaternion.identity).name = gameObject.name + myWave[0] + "(Clone)";
        myEnemy.Add(GameObject.Find(gameObject.name + myWave[0] + "(Clone)"));

        if(myWave.Count > 0)
            myWave.RemoveAt(0);
        CancelInvoke();
    }
}
