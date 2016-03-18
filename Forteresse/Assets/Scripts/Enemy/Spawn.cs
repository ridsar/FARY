using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {

    public GameObject enemies;
    public int amount = 0;
    public float spawingTime;
    public int enemyNumber;

    private List<string> myWave = new List<string>();

    private Vector3 spawnPoints;

    void Start()
    {
        switch (name)
        {
            case "A":
                spawingTime = 1;
                enemyNumber = 20;
                myWave.Add("Enemy"); myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy");
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
                myWave.Add("Enemy"); myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy");
                break;
            case "D":
                spawingTime = 2;
                enemyNumber = 10;
                myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Enemy");
                myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Goblin"); myWave.Add("Enemy");
                break;
            case "E":
                spawingTime = 2.5f;
                enemyNumber = 4;
                myWave.Add("Goblin"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy");
                break;
        }
    }

	void Update ()
    {
                   
        if (amount != enemyNumber)
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
        ++amount;
        CancelInvoke();
    }
}
