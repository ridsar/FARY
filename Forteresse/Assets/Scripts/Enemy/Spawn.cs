using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject[] enemies;
    public int amount = 0;
    public float spawingTime;
    public int enemyNumber;

    private Vector3 spawnPoints;


	void Update ()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        
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

        Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Length - 1)], spawnPoints, Quaternion.identity);
        ++amount;
        CancelInvoke();
    }
}
