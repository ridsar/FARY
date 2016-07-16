using UnityEngine;
using System.Collections;
using UnityEngine.Networking;



public class BuildRes : NetworkBehaviour
{
    [SerializeField] GameObject Mage_Tower;
    [SerializeField] GameObject Canon_Tower;
    [SerializeField] GameObject Fire_Tower;
    [SerializeField] GameObject Frozen_Tower;
    [SerializeField] GameObject Tower_Buffer;
    [SerializeField] GameObject Stun_Trap;
    [SerializeField] GameObject Lava_Floor;

    public GameObject[] Tower;

    GameObject my_object;
    GameObject T;
    GameObject tempT;
    Vector3 posT;
    Quaternion rotT;

    private Vector3 spawnPoints;
    private Vector3 boxSize;

    public bool canBuild = false;
    public bool Buildable = true;

    string name = "";
    string path;

    int price;
    int type;
    int decal = 0;

    Attack attackScript;

    void Start()
    {
         
    }
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        //Déclaration variables
        Tower = GameObject.FindGameObjectsWithTag("Tower");
        //Detruire un tour en jeu
        if (Input.GetKey(KeyCode.E)) //Appuyez sur E pour detruire la tour
        {
            RaycastHit hit; //Creation d'un Raycast pour detecter la tour a detruire 

            if (Physics.Raycast(transform.position, transform.forward * 10, out hit)) //Le raycast va de 0 à 10 a partir du personnage devant lui
            {
                if (hit.collider.gameObject.tag == "Tower" && hit.distance <= 10) // si l'objet hit est une tour 
                {
                    Destroy(hit.collider.gameObject); // detruit la tour
                }
            }
        }

        //Instanciation d'un model de tour pour visualisation
        if (Input.GetKey(KeyCode.Alpha1) && !canBuild && GetComponent<PickUpMoneyRes>().money >= 10)
        {
            my_object = Mage_Tower;

            name = "Mage Tower"; //Paramètre pour la tour a instancier
            type = 0;
            path = "Walls";
            price = 10;
            boxSize = new Vector3(0.6f, 1.5f, 0.6f);

            canBuild = true; //variable disant si je peux poser une tour ou pas

            invokTower(); //Lance la Coroutine qui va instancier la tour
        }

        else if (Input.GetKey(KeyCode.Alpha2) && !canBuild && GetComponent<PickUpMoneyRes>().money >= 20)
        {
            my_object = Canon_Tower;

            name = "Canon Tower"; //Paramètre pour la tour a instancier
            type = 2;
            path = "Walls";
            price = 20;
            boxSize = new Vector3(4.3f, 12.0f, 4.3f);

            canBuild = true; //variable disant si je peux poser une tour ou pas
            invokTower(); //Lance la Coroutine qui va instancier la tour
        }
        else if (Input.GetKey(KeyCode.Alpha3) && !canBuild && GetComponent<PickUpMoneyRes>().money >= 30)
        {
            my_object = Lava_Floor;

            name = "Lava Floor";
            type = 1;
            path = "/Lava Floor(Clone)";
            price = 30;

            canBuild = true;
            invokTower();

        }
        else if (Input.GetKey(KeyCode.Alpha4) && !canBuild && GetComponent<PickUpMoneyRes>().money >= 20)
        {
            my_object = Fire_Tower;
            name = "Fire Tower";
            type = 3;
            path = "Walls";
            price = 20;
            boxSize = new Vector3(0.2f, 1.5f, 0.2f);

            canBuild = true;
            invokTower();
        }
        else if (Input.GetKey(KeyCode.Alpha5) && !canBuild && GetComponent<PickUpMoneyRes>().money >= 50)
        {
            my_object = Tower_Buffer;
            name = "Tower Buffer";
            type = 4;
            path = "Runestone";
            price = 50;
            boxSize = new Vector3(1.7f, 8f, 1.7f);

            canBuild = true;
            invokTower();
        }
        else if (Input.GetKey(KeyCode.Alpha6) && !canBuild && GetComponent<PickUpMoneyRes>().money >= 50)
        {
            my_object = Stun_Trap;
            name = "Stun Trap";
            type = 5;
            path = "tap";
            price = 50;
            decal = -17;

            canBuild = true;
            invokTower();
        }
        else if (Input.GetKey(KeyCode.Alpha7) && !canBuild && GetComponent<PickUpMoneyRes>().money >= 0)
        {
            my_object = Frozen_Tower;
            name = "Frozen Tower";
            type = 6;
            path = "Mesh";
            price = 0;
            decal = 0;
            boxSize = new Vector3(5f, 10f, 5f);

            canBuild = true;
            invokTower();
        }

            //l'objet suit la souris
            if (canBuild) //Lorsque l'une des tour a été selectionné
            {

                double cosAngle = Mathf.Cos(transform.eulerAngles.y * Mathf.PI / 180); //Permet de maintenir la tour devant meme lors de rotation
                double sinAngle = Mathf.Sin(transform.eulerAngles.y * Mathf.PI / 180);
                if (name == "Canon Tower" || name == "Mage Tower" || name == "Frozen Tower")
                {

                }
                if (name == "Canon Tower" || name == "Mage Tower" || name == "Frozen Tower")
                {
                    attackScript = T.GetComponent<Attack>();
                    attackScript.enabled = false; //Eteint le script "Attck" sur la tour
                }

                Vector3 playerPos = transform.position; //Position actuelle du joueur
                Vector3 towerPos = T.transform.position; //Position actuelle de la tour

                T.transform.rotation = transform.rotation;
                T.GetComponent<BoxCollider>().isTrigger = true; //Desactivation du collider
                if (name == "Canon Tower" || name == "Mage Tower" || name == "Fire Tower" || name == "Tower Buffer" || name == "Frozen Tower")
                {
                    T.GetComponent<SphereCollider>().enabled = false;
                }
                T.transform.position = new Vector3(playerPos.x + 20 * (float)sinAngle, 0 + decal, playerPos.z + 20 * (float)cosAngle); //Modifie la position de la tour en fonction de la pos du joueur

                if (name == "Mage Tower" || name == "Canon Tower" || name == "Frozen Tower" || name == "Tower Buffer" || name == "Fire Tower")
                {
                    Buildable = true;

                    foreach (Collider other in Physics.OverlapBox(T.transform.position, boxSize))
                    {
                        if (other.tag == "NoBuild")
                            Buildable = false;
                    }

                    if (Buildable)
                        T.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = new Color(0.2f, 1.0f, 0.2f, 1.0f);
                    else
                        T.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = new Color(1.0f, 0.2f, 0.2f, 1.0f);
                }




                //l'objet est construit pour de vrai en jeu 
                if ((Buildable && canBuild && Input.GetMouseButton(0)) || Input.GetMouseButton(1))
                {
                    //Déclaration de variable

                    if (Input.GetMouseButton(1) && T != null) //clic droit
                    {
                        if (T != null)
                        {
                            Destroy(T); //detruit la tour
                            canBuild = false; //on ne peut plus poser de tour il faut re-choisir une tour
                            Buildable = true;
                        }
                    }
                    if (T != null)
                    {
                        if (name == "Canon Tower" || name == "Mage Tower" || name == "Frozen Tower")
                            attackScript.enabled = true; //Le script d'attack est désormais activé
                    }

                    //=====================================
                    //Moment ou l'on va instancier la tour
                    //=====================================




                    if (Input.GetMouseButton(0)) //clic gauche
                    {
                        GetComponent<PickUpMoneyRes>().money -= price;
                        print(GetComponent<PickUpMoneyRes>().money);

                        if (T != null)
                        {
                            tempT = T;
                            posT = T.transform.position;
                            rotT = T.transform.rotation;
                        }

                        Destroy(T);

                        CmdSetTower(tempT, rotT, posT, name, path);

                        canBuild = false; //on ne peut plus poser de tour il faut re-choisir une tour
                        Buildable = true;

                        decal = 0;
                    }
                }
            
        }
    }


    //Clone l'objet voulu
     void invokTower()
    {
        T = Instantiate(my_object, new Vector3(transform.position.x, transform.position.y + decal, transform.position.z + 20), Quaternion.identity) as GameObject; //créer l'objet (la tour dans ce cas)
        T.SetActive(true);
        T.name = name + "(Clone)";

        CancelInvoke(); //arrete la creation de tour

        if(name == "Lava Floor")
            GetComponent<MeshRenderer>().material.color = new Color(0.2f, 1.0f, 0.2f, 1.0f); //La tour devient verte
        else
            T.transform.FindChild(path).GetComponent<MeshRenderer>().material.color = new Color(0.2f, 1.0f, 0.2f, 1.0f); //La tour devient verte
    }


    [Command]
    void CmdSetTower(GameObject tempT, Quaternion rot, Vector3 pos, string name, string path)
    {
        switch (name)
        {
            case "Mage Tower":
                T = Instantiate(Mage_Tower) as GameObject;
                T.SetActive(true);
                T.transform.position = pos;
                T.transform.rotation = rot;
                break;
            case "Canon Tower":
                T = Instantiate(Canon_Tower) as GameObject;
                T.SetActive(true);
                T.transform.position = pos;
                T.transform.rotation = rot;            
                break;
            case "Frozen Tower":
                T = Instantiate(Frozen_Tower) as GameObject;
                T.SetActive(true);
                T.transform.position = pos;
                T.transform.rotation = rot;
                break;
            case "Fire Tower":
                T = Instantiate(Fire_Tower) as GameObject;
                T.SetActive(true);
                T.transform.position = pos;
                T.transform.rotation = rot;
                break;
            case "Tower Buffer":
                T = Instantiate(Tower_Buffer) as GameObject;
                T.SetActive(true);
                T.transform.position = pos;
                T.transform.rotation = rot;
                break;
            case "Lava Floor":
                T = Instantiate(Lava_Floor) as GameObject;
                T.SetActive(true);
                T.transform.position = pos;
                T.transform.rotation = rot;
                break;
            case "Stun Trap":
                T = Instantiate(Stun_Trap) as GameObject;
                T.SetActive(true);
                T.transform.position = pos;
                T.transform.rotation = rot;
                break;
        }



        //T = Instantiate(tempT) as GameObject;
        T.name = name + "(Clone)";

        //réactive le collider de la tour
        if (name != "Stun Trap")
            T.GetComponent<BoxCollider>().isTrigger = false;

        if (name == "Canon Tower" || name == "Mage Tower" || name == "Fire Tower" || name == "Tower Buffer" || name == "Frozen Tower")
        {
            T.GetComponent<SphereCollider>().enabled = true;
            T.transform.GetChild(2).GetComponent<BoxCollider>().enabled = true;
        }
        if (name == "Tower Buffer")
        {
            T.transform.GetChild(0).gameObject.SetActive(true);
        }

        if (name == "Canon Tower" || name == "Mage Tower" || name == "Frozen Tower")
            T.GetComponent<Attack>().enabled = true; //Le script d'attack est désormais activé

        //remet les couleurs de la tour
        GameObject walls;
        if (name == "Lava Floor")
            walls = T;
        else
            walls = T.transform.FindChild(path).gameObject;

        walls.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        if (name == "Frozen Tower")
        {
            walls.SetActive(false);
        }

        T.name = name + "(Build)"; //On change le nom de la tour avec "(Build)" pour la differentier des autres tours
        NetworkServer.Spawn(T);
    }
}