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

    private Vector3 spawnPoints;

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
        if (isLocalPlayer)
        {
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
            if (Input.GetKey(KeyCode.Alpha1) && !canBuild && GetComponent<pickUpMoney>().money >= 10)
            {
                my_object = Mage_Tower;

                name = "Mage Tower"; //Paramètre pour la tour a instancier
                type = 0;
                path = "Walls";
                price = 10;
                canBuild = true; //variable disant si je peux poser une tour ou pas
                CmdinvokTower(); //Lance la Coroutine qui va instancier la tour
            }

            else if (Input.GetKey(KeyCode.Alpha2) && !canBuild && GetComponent<pickUpMoney>().money >= 20)
            {
                my_object = Canon_Tower;

                name = "Canon Tower"; //Paramètre pour la tour a instancier
                type = 2;
                path = "Walls";
                price = 20;

                canBuild = true; //variable disant si je peux poser une tour ou pas
                CmdinvokTower(); //Lance la Coroutine qui va instancier la tour
            }
            else if (Input.GetKey(KeyCode.Alpha3) && !canBuild && GetComponent<pickUpMoney>().money >= 30)
            {
                my_object = Lava_Floor;

                name = "Lava Floor";
                type = 1;
                path = "/Lava Floor(Clone)";
                price = 30;

                canBuild = true;
                CmdinvokTower();

            }
            else if (Input.GetKey(KeyCode.Alpha4) && !canBuild && GetComponent<pickUpMoney>().money >= 20)
            {
                my_object = Fire_Tower;
                name = "Fire Tower";
                type = 3;
                path = "Walls";
                price = 20;

                canBuild = true;
                CmdinvokTower();
            }
            else if (Input.GetKey(KeyCode.Alpha5) && !canBuild && GetComponent<pickUpMoney>().money >= 50)
            {
                my_object = Tower_Buffer;
                name = "Tower Buffer";
                type = 4;
                path = "Runestone";
                price = 50;

                canBuild = true;
                CmdinvokTower();
            }
            else if (Input.GetKey(KeyCode.Alpha6) && !canBuild && GetComponent<pickUpMoney>().money >= 50)
            {
                my_object = Stun_Trap;
                name = "Stun Trap";
                type = 5;
                path = "tap";
                price = 50;
                decal = -17;

                canBuild = true;
                CmdinvokTower();
            }
            else if (Input.GetKey(KeyCode.Alpha7) && !canBuild && GetComponent<pickUpMoney>().money >= 0)
            {
                my_object = Frozen_Tower;
                name = "Frozen Tower";
                type = 6;
                path = "Mesh";
                price = 0;
                decal = 0;

                canBuild = true;
               CmdinvokTower();
            }

            //l'objet suit la souris
            if (canBuild) //Lorsque l'une des tour a été selectionné
            {
                var player = GameObject.Find("Player");
                var tour = GameObject.Find(name + "(Clone)"); //Ajout du mot "(Clone)" pour differentier la tour des autres tour deja construite

                double cosAngle = Mathf.Cos(transform.eulerAngles.y * Mathf.PI / 180); //Permet de maintenir la tour devant meme lors de rotation
                double sinAngle = Mathf.Sin(transform.eulerAngles.y * Mathf.PI / 180);
                if (name == "Canon Tower" || name == "Mage Tower" || name == "Frozen Tower" )
                {

                }
                    if (name == "Canon Tower" || name == "Mage Tower" || name == "Frozen Tower")
                {
                    attackScript = T.GetComponent<Attack>();
                    attackScript.enabled = false; //Eteint le script "Attck" sur la tour

                    T.GetComponent<CanBuildHereRes>().enabled = true;
                }


                Vector3 playerPos = player.transform.position; //Position actuelle du joueur
                Vector3 towerPos = T.transform.position; //Position actuelle de la tour

                T.transform.rotation = player.transform.rotation;
                T.GetComponent<BoxCollider>().isTrigger = true; //Desactivation du collider
                if (name == "Canon Tower" || name == "Mage Tower" || name == "Fire Tower" || name == "Tower Buffer" || name == "Frozen Tower")
                {
                    T.GetComponent<SphereCollider>().enabled = false;
                }
                T.transform.position = new Vector3(playerPos.x + 20 * (float)sinAngle, 0 + decal, playerPos.z + 20 * (float)cosAngle); //Modifie la position de la tour en fonction de la pos du joueur


            }


            //l'objet est construit pour de vrai en jeu 
            if ((Buildable && canBuild && Input.GetMouseButton(0)) || Input.GetMouseButton(1))
            {
                //Déclaration de variable
                var player = GameObject.Find("Player");

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
                    Vector3 playerPos = player.transform.position;
                    Vector3 towerPos = T.transform.position;



                    if (name == "Canon Tower" || name == "Mage Tower" || name == "Fire Tower" || name == "Tower Buffer" || name == "Frozen Tower")
                    {
                        T.GetComponent<CanBuildHereRes>().enabled = false;
                        if (name == "Canon Tower" || name == "Mage Tower" || name == "Frozen Tower")
                            attackScript.enabled = true; //Le script d'attack est désormais activé
                    }
                }

                if (Input.GetMouseButton(0)) //clic gauche
                {
                    GetComponent<pickUpMoney>().money -= price;
                    print(GetComponent<pickUpMoney>().money);
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
                    //remet les couleurs de la tour
                    GameObject walls;
                    if (name == "Lava Floor")
                        walls = T;
                    else
                        walls = T.transform.FindChild(path).gameObject;

                    walls.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    canBuild = false; //on ne peut plus poser de tour il faut re-choisir une tour
                    Buildable = true;

                    if (name == "Frozen Tower")
                    {
                        walls.SetActive(false);
                    }

                    T.name = name + "(Build)"; //On change le nom de la tour avec "(Build)" pour la differentier des autres tours
                    decal = 0;
                }
            }
        }
    }


    //Clone l'objet voulu
    [Command]
     void CmdinvokTower() 
    {
        T = Instantiate(my_object, new Vector3(transform.position.x, transform.position.y + decal, transform.position.z + 20), Quaternion.identity) as GameObject; //créer l'objet (la tour dans ce cas)
        T.SetActive(true);
        NetworkServer.Spawn(T);
        T.name += "(Clone)";

        CancelInvoke(); //arrete la creation de tour
        if (name == "Canon Tower" || name == "Mage Tower" || name == "Fire Tower" || name == "Tower Buffer" || name == "Frozen Tower")
        {
            //T.GetComponent<CanBuildHere>().enabled = true;  
        }
        if(name == "Lava Floor")
            GetComponent<MeshRenderer>().material.color = new Color(0.2f, 1.0f, 0.2f, 1.0f); //La tour devient verte
        else
            T.transform.FindChild(path).GetComponent<MeshRenderer>().material.color = new Color(0.2f, 1.0f, 0.2f, 1.0f); //La tour devient verte
       // yield return new WaitForSeconds(0); //temps avant d'effectuer les instructions précedente (0 sec dans ce cas)
    }
}