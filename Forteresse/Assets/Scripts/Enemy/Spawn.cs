using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject enemies;
    public int amount = 0;
    public float spawingTime;
    public int enemyNumber;

    private Vector3 spawnPoints;


	void Update ()
    {
        switch (name)
        {
            case "A":
                spawingTime = 1;
                amount = 20;
                enemies = GameObject.Find("Enemy");
                break;
            case "B":
                spawingTime = 3;
                amount = 3;
                enemies = GameObject.Find("Enemy");
                break;
            case "C":
                spawingTime = 10;
                amount = 5;
                enemies = GameObject.Find("Enemy");
                break; 
            case "D":
                spawingTime = 2;
                amount = 10;
                enemies = GameObject.Find("Enemy");
                break;
            case "E":
                spawingTime = 2.5f;
                amount = 4;
                enemies = GameObject.Find("Enemy");
                break;
        }
        
        
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

        Instantiate(enemies, spawnPoints, Quaternion.identity).name = gameObject.name + "Enemy(Clone)";
        ++amount;
        CancelInvoke();
    }
}
