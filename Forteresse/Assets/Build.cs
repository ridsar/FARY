﻿using UnityEngine;
using System.Collections;

public class Build : MonoBehaviour
{
    public GameObject[] Tower;
    private Vector3 spawnPoints;
    bool canBuild = false; //FIXEME


    void Update()
    {


        //Déclaration variables
        Tower = GameObject.FindGameObjectsWithTag("Tower");
        var Field = GameObject.Find("Terrain");



        //Instanciation d'un model de tour pour visualisation
        if (Input.GetKey(KeyCode.Alpha1) && !canBuild)
        {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                canBuild = true;

                float x = hit.point.x;
                float y = hit.point.y;
                float z = hit.point.z;

                StartCoroutine(spawnEnemy(x, y, z));
                var tour = GameObject.Find("Tower(Clone)");                              
            }         
        }


        //l'objet suit la souris
        if (canBuild)
        {
            var tour = GameObject.Find("Tower(Clone)");
            float distance = 20;
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, 100, Input.mousePosition.y / 2);
            print(Input.mousePosition);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            objPosition.y = 2;
            tour.transform.position = objPosition;


           /* RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                var tour = GameObject.Find("Tower(Clone)");
                tour.transform.position = hit.point;
            }
            print(Camera.main.ScreenPointToRay(Input.mousePosition));*/
        }
       

        //l'objet est construit pour de vrai en jeu 
        if (Input.GetMouseButton(1) && canBuild)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                float x = hit.point.x;
                float y = hit.point.y;
                float z = hit.point.z;
                if (y == Field.transform.position.y)
                    StartCoroutine(spawnEnemy(x, y, z));
                    canBuild = false; // FIXEME
            }
            GameObject.Find("Tower(Clone)").name = "Tower(Build)";
        }       
    }


    //Clone l'objet voulu
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
