using UnityEngine;
using System.Collections;

public class Build : MonoBehaviour
{

    public GameObject[] Tower;
    private Vector3 spawnPoints;



    void Update()
    {
        Tower = GameObject.FindGameObjectsWithTag("Tower");
        if (Input.GetMouseButton(1))
        {
            Invoke("spawnEnemy", 0);
        }
    }

    void spawnEnemy()
    {
        spawnPoints.x = transform.position.x;
        spawnPoints.y = transform.position.y;
        spawnPoints.z = transform.position.z;

        Instantiate(Tower[UnityEngine.Random.Range(0, Tower.Length - 1)], spawnPoints, Quaternion.identity);
        CancelInvoke();
    }
}
