using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class SpawnReseau : MonoBehaviour {
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
        //if (isLocalPlayer)
        //{
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
                                spawingTime = 2; //temps entre le spawn de chaque enemie
                                myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy"); //ajout a une liste des enemies a faire pop 
                                myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy");
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
                                myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy");
                                break;
                        }
                        break;
                    case 4:
                        switch (name)
                        {
                            case "A":
                                spawingTime = 1;
                                myWave.Add("Troll");
                                myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy");
                                myWave.Add("Troll");
                                myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy");
                                myWave.Add("Troll");
                                break;
                            case "B":
                                spawingTime = 3;
                                myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy");
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
                                myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy");
                                myWave.Add("Troll"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin");

                                break;
                            case "B":
                                spawingTime = 1.5f;
                                myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy");
                                myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy"); myWave.Add("Enemy");
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
                                spawingTime = 1;
                                myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin");
                                myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin");
                                myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin");
                                break;
                            case "B":
                                spawingTime = 1f;
                                myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin");
                                break;
                            case "C":
                                myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin");

                                spawingTime = 1;
                                break;
                            case "D":
                                myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin");

                                spawingTime = 1;
                                break;
                            case "E":
                                spawingTime = 1f;
                                myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin"); myWave.Add("Goblin");
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
    //}
    void spawnEnemy()
    {
        //coordonnée de spawn
        spawnPoints.x = Random.Range(-20 + transform.position.x, 20 + transform.position.x);
        spawnPoints.y = 0.5f;
        spawnPoints.z = Random.Range(-20 + transform.position.z, 20 + transform.position.z);

        Instantiate(GameObject.Find(myWave[0]), spawnPoints, Quaternion.identity).name = gameObject.name + myWave[0] + "(Clone)"; //Créer l'enemie
        CancelInvoke();

        myEnemy.Add(GameObject.Find(gameObject.name + myWave[0] + "(Clone)")); //ajout de l'enemie spawn a la liste des enemies en vie

        if (myWave.Count > 0) //retire un element de la liste des enemies a faire spawn
            myWave.RemoveAt(0);
    }
}