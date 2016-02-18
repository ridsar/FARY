using UnityEngine;
using System.Collections;


public class Build : MonoBehaviour
{
    public GameObject[] Tower;
    private Vector3 spawnPoints;
    bool canBuild = false;


    void Update()
    {

        this.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);

        //Déclaration variables
        Tower = GameObject.FindGameObjectsWithTag("Tower");


        //Instanciation d'un model de tour pour visualisation
        if (Input.GetKey(KeyCode.Alpha1) && !canBuild)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                canBuild = true;

                float x = hit.point.x;
                float y = hit.point.y;
                float z = hit.point.z;

                StartCoroutine(spawnEnemy(x, y, z));
            }
        }


        //l'objet suit la souris
        if (canBuild)
        {

            var player = GameObject.Find("Player");
            var tour = GameObject.Find("Tower(Clone)");


            Vector3 playerPos = player.transform.position;
            Vector3 towerPos = tour.transform.position;

            tour.GetComponent<Collider>().enabled = false;
            Cursor.visible = false;

            Vector3 mousePosition = new Vector3(Input.mousePosition.x, 100, Input.mousePosition.y / 2);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            objPosition.y = 0;
            tour.transform.position = objPosition;




            var walls = GameObject.Find("/Tower(Clone)/Walls");

            if (playerPos.x - towerPos.x > 50 || playerPos.x - towerPos.x < -50 || playerPos.z - towerPos.z > 50 || playerPos.z - towerPos.z < -50)
            {
                walls.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 0.2f, 0.2f, 1.0f);
            }
            else
                walls.GetComponent<MeshRenderer>().material.color = new Color(0.2f, 1.0f, 0.2f, 1.0f);


        }


        //l'objet est construit pour de vrai en jeu 
        if (canBuild)
        {
            var player = GameObject.Find("Player");
            var tour = GameObject.Find("Tower(Clone)");


            Vector3 playerPos = player.transform.position;
            Vector3 towerPos = tour.transform.position;

            if (Input.GetMouseButton(0) && !(playerPos.x - towerPos.x > 50 || playerPos.x - towerPos.x < -50 || playerPos.z - towerPos.z > 50 || playerPos.z - towerPos.z < -50))
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    var walls = GameObject.Find("/Tower(Clone)/Walls");

                    tour.GetComponent<Collider>().enabled = true;
                    Cursor.visible = true;

                    walls.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

                    canBuild = false;
                }
                GameObject.Find("Tower(Clone)").name = "Tower(Build)";
            }
        }  
    }


    //Clone l'objet voulu
    IEnumerator spawnEnemy(float x, float y, float z)
    {
        spawnPoints.x = x;
        spawnPoints.y = y;
        spawnPoints.z = z;

        Instantiate(Tower[UnityEngine.Random.Range(0, Tower.Length - 1)], spawnPoints, Quaternion.identity).name = "Tower(Clone)";
        CancelInvoke();
        yield return new WaitForSeconds(0);
    }
}
