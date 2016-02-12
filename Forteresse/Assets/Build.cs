using UnityEngine;
using System.Collections;

public class Build : MonoBehaviour
{
    public GameObject[] Tower;
    private Vector3 spawnPoints;

    void Update()
    {
        Tower = GameObject.FindGameObjectsWithTag("Tower");
        var Field = GameObject.Find("Terrain");

        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                float x =  hit.point.x;
                float y = hit.point.y;
                float z = hit.point.z;
                if (y == Field.transform.position.y)
                    StartCoroutine(spawnEnemy(x, y, z));
            }
        }

        

    }

    IEnumerator spawnEnemy(float x, float y, float z)
    {
        spawnPoints.x = x;
        spawnPoints.y = y;
        spawnPoints.z = z;

        Instantiate(Tower[UnityEngine.Random.Range(0, Tower.Length - 1)], spawnPoints, Quaternion.identity);
        CancelInvoke();
        yield return new WaitForSeconds(0);
    }
}
