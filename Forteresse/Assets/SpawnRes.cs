﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class SpawnRes : NetworkBehaviour
{

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

    void Update()
    {
        if (Input.GetKey(KeyCode.F) && !check)
        {
            print("ceci est le spawn : " + name);
            // pour test
            switch (waveNb) //regarde le numero de la vague a laquelle on est
            {
                case 1:
                    switch (name) //regarde le spawn ou l'on doit spawn le mob
                    {
                        case "A":
                            spawingTime = 1; //temps entre le spawn de chaque enemie
                            myWave.Add("Necromancer"); myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Overseer"); //ajout a une liste des enemies a faire pop 
                            myWave.Add("Ranger"); myWave.Add("Ranger"); myWave.Add("Ranger"); myWave.Add("Ranger"); myWave.Add("Ranger");
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
                            spawingTime = 0.5f;
                            myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin");
                            myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin");
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

                case 3:
                    switch (name)
                    {
                        case "A":
                            spawingTime = 1;
                            myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin");
                            myWave.Add("Ranger"); myWave.Add("Ranger"); myWave.Add("Ranger"); myWave.Add("Ranger"); myWave.Add("Ranger");
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
                            spawingTime = 1f;
                            myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton");
                            myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton");
                            break;
                    }
                    break;
                case 4:
                    switch (name)
                    {
                        case "A":
                            spawingTime = 0.8f;
                            myWave.Add("Troll");
                            myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton");
                            myWave.Add("Troll");
                            myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton");
                            myWave.Add("Troll");
                            myWave.Add("Ranger"); myWave.Add("Ranger"); myWave.Add("Ranger"); myWave.Add("Ranger"); myWave.Add("Ranger");
                            break;
                        case "B":
                            spawingTime = 1.5f;
                            myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton");
                            myWave.Add("Skeleton"); myWave.Add("Skeleton");
                            break;
                        case "C":
                            spawingTime = 10;
                            break;
                        case "D":
                            spawingTime = 2;
                            break;
                        case "E":
                            spawingTime = 1.5f;
                            myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin");
                            break;
                    }
                    break;
                case 5:
                    switch (name)
                    {
                        case "A":
                            spawingTime = 1;
                            myWave.Add("Troll"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin");
                            myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton");
                            myWave.Add("Troll"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin");

                            break;
                        case "B":
                            spawingTime = 1.5f;
                            myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton");
                            myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton");
                            break;
                        case "C":
                            spawingTime = 10;
                            break;
                        case "D":
                            myWave.Add("Troll"); myWave.Add("Troll");
                            spawingTime = 10;
                            break;
                        case "E":
                            spawingTime = 1.5f;
                            myWave.Add("Troll");
                            myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin");
                            myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin");
                            break;
                    }
                    break;
                case 6:
                    switch (name)
                    {
                        case "A":
                            spawingTime = 0.3f;
                            myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton");
                            myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton");
                            myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin");
                            break;
                        case "B":
                            spawingTime = 1f;
                            myWave.Add("Hell Keeper");
                            myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin");
                            myWave.Add("Hell Keeper");
                            break;
                        case "C":
                            myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin");
                            myWave.Add("Hell Keeper");
                            spawingTime = 1;
                            break;
                        case "D":
                            myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin");
                            spawingTime = 0.5f;
                            break;
                        case "E":
                            spawingTime = 1f;
                            myWave.Add("Hell Keeper");
                            myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin");
                            break;
                    }
                    break;
                case 7:
                    switch (name)
                    {
                        case "A":
                            spawingTime = 1;
                            myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton");
                            myWave.Add("Hell Keeper"); myWave.Add("Hell Keeper"); myWave.Add("Hell Keeper"); myWave.Add("Hell Keeper");
                            myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin");
                            break;
                        case "B":
                            spawingTime = 1f;
                            myWave.Add("Hell Keeper"); myWave.Add("Hell Keeper"); myWave.Add("Hell Keeper"); myWave.Add("Hell Keeper");
                            myWave.Add("Troll"); myWave.Add("Troll"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin");
                            myWave.Add("Hell Keeper");
                            break;
                        case "C":
                            myWave.Add("Troll"); myWave.Add("Troll"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin");
                            myWave.Add("Ranger"); myWave.Add("Ranger"); myWave.Add("Ranger"); myWave.Add("Ranger"); myWave.Add("Ranger");
                            myWave.Add("Hell Keeper");
                            spawingTime = 1;
                            break;
                        case "D":
                            myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin");
                            myWave.Add("Ranger"); myWave.Add("Ranger"); myWave.Add("Ranger"); myWave.Add("Ranger"); myWave.Add("Ranger");
                            spawingTime = 1;
                            break;
                        case "E":
                            spawingTime = 0.5f;
                            myWave.Add("Hell Keeper");
                            myWave.Add("Troll"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin");
                            break;
                    }
                    break;
            }
            ++waveNb; //On incrémente de 1, pour passer a la vague suivante
            check = true;
        }
        else if (check && transform.parent.GetComponent<Wave>().check) //si les deux check sont true alors on peut lancer une nouvelle vague
        {
            //pemret de relancer un vague
            check = false;
            transform.parent.GetComponent<Wave>().check = false;
        }
        if (myWave.Count > 0 && check) //tant qu'il reste des elements dans la liste
        {
            InvokeRepeating("spawnEnemy", spawingTime, 10f); //appel la methode spawnEnemy
        }
    }

    [Command]
    void CmdspawnEnemy()
    {
        //coordonnée de spawn
        spawnPoints.x = Random.Range(-10 + transform.position.x, 10 + transform.position.x);
        spawnPoints.y = 0.5f;
        spawnPoints.z = Random.Range(-10 + transform.position.z, 10 + transform.position.z);

        GameObject enemy = Instantiate(GameObject.Find(myWave[0]), spawnPoints, Quaternion.identity) as GameObject; //Créer l'enemie
        NetworkServer.Spawn(enemy);
        enemy.name = gameObject.name + myWave[0] + "(Clone)";
        if (enemy.name == gameObject.name + "Necromancer(Clone)")
            enemy.GetComponent<InvokSkeleton>().enabled = true;

        CancelInvoke();

        myEnemy.Add(GameObject.Find(gameObject.name + myWave[0] + "(Clone)")); //ajout de l'enemie spawn a la liste des enemies en vie

        if (myWave.Count > 0) //retire un element de la liste des enemies a faire spawn
            myWave.RemoveAt(0);
    }
}
