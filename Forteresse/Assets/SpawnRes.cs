using UnityEngine;
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

    public GameObject Skeleton;
    public GameObject Goblin;
    public GameObject Troll;
    public GameObject Ranger;
    public GameObject Hell_Keeper;
    public GameObject Necromancer;
    public GameObject Overseer;

    private float time;

    void Start()
    {
        time = -1;
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
                            myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton"); myWave.Add("Skeleton"); //ajout a une liste des enemies a faire pop 
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
        else if (check && transform.parent.GetComponent<WaveRes>().check) //si les deux check sont true alors on peut lancer une nouvelle vague
        {
            //pemret de relancer un vague
            check = false;
            transform.parent.GetComponent<WaveRes>().check = false;
        }
        if (time >= 0)
            time -= 1 * Time.deltaTime;

        if (myWave != null && myWave.Count > 0 && check && time < 0) //tant qu'il reste des elements dans la liste
        {
            string name = myWave[0];
            CmdspawnEnemy(name, gameObject.name); //appel la methode spawnEnemy
            time = spawingTime;
            if (myWave.Count > 0) //retire un element de la liste des enemies a faire spawn
                myWave.RemoveAt(0);
          

        }
    }

    [Command]
    void CmdspawnEnemy(string name, string spawn)
    {
        GameObject enemy = null;
        //coordonnée de spawn
        spawnPoints.x = Random.Range(-10 + transform.position.x, 10 + transform.position.x);
        spawnPoints.y = 0.5f;
        spawnPoints.z = Random.Range(-10 + transform.position.z, 10 + transform.position.z);

        switch (name)
        {
            case "Skeleton":
                enemy = Instantiate(Skeleton, spawnPoints, Quaternion.identity) as GameObject; //Créer l'enemie
                break;
            case "Goblin":
                enemy = Instantiate(Goblin, spawnPoints, Quaternion.identity) as GameObject; //Créer l'enemie
                break;
            case "Troll":
                enemy = Instantiate(Troll, spawnPoints, Quaternion.identity) as GameObject; //Créer l'enemie
                break;
            case "Ranger":
                enemy = Instantiate(Ranger, spawnPoints, Quaternion.identity) as GameObject; //Créer l'enemie
                break;
            case "Hell Keeper":
                enemy = Instantiate(Hell_Keeper, spawnPoints, Quaternion.identity) as GameObject; //Créer l'enemie
                break;
            case "Necromancer":
                enemy = Instantiate(Necromancer, spawnPoints, Quaternion.identity) as GameObject; //Créer l'enemie
                break;
            case "Overseer":
                enemy = Instantiate(Overseer, spawnPoints, Quaternion.identity) as GameObject; //Créer l'enemie
                break;
        }

        if (name == "Necromancer")
            enemy.GetComponent<InvokSkeleton>().enabled = true;

        CancelInvoke();
        enemy.name = spawn + name + "(Clone)";
        NetworkServer.Spawn(enemy);
        //Rpcrename(enemy.name, name, spawn);

        myEnemy.Add(GameObject.Find(spawn + name + "(Clone)")); //ajout de l'enemie spawn a la liste des enemies en vie
    }

    /*[ClientRpc]
    void Rpcrename(string id, string name, string spawn)
    {
        GameObject temps = GameObject.Find(id);
        temps.name = spawn + name + "(Clone)";
        temps.GetComponent<FollowPathRes>().enabled = true;
        print(id);
    }*/
}
