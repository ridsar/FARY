using UnityEngine;
using System.Collections;


public class Build : MonoBehaviour
{
    public GameObject[] Tower;

    private Vector3 spawnPoints;

    public bool canBuild = false;
    public bool isBuildable = true;

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
            name = "Mage Tower"; //Paramètre pour la tour a instancier
            type = 0;
            path = "/Mage Tower(Clone)/Walls";
            price = 10;

            canBuild = true; //variable disant si je peux poser une tour ou pas
            StartCoroutine(invokTower()); //Lance la Coroutine qui va instancier la tour
        }

        else if (Input.GetKey(KeyCode.Alpha2) && !canBuild && GetComponent<pickUpMoney>().money >= 20)
        {
            name = "Canon Tower"; //Paramètre pour la tour a instancier
            type = 2;
            path = "/Canon Tower(Clone)/Walls";
            price = 20;

            canBuild = true; //variable disant si je peux poser une tour ou pas
            StartCoroutine(invokTower()); //Lance la Coroutine qui va instancier la tour
        }
        else if (Input.GetKey(KeyCode.Alpha3) && !canBuild && GetComponent<pickUpMoney>().money >= 30)
        {
            name = "Lava Floor";
            type = 1;
            path = "/Lava Floor(Clone)";
            price = 30;

            canBuild = true;
            StartCoroutine(invokTower());
            
        }
        else if (Input.GetKey(KeyCode.Alpha4) && !canBuild && GetComponent<pickUpMoney>().money >= 20)
        {
            name = "Fire Tower";
            type = 3;
            path = "/Fire Tower(Clone)/Walls";
            price = 20;

            canBuild = true;
            StartCoroutine(invokTower());
        }
        else if (Input.GetKey(KeyCode.Alpha5) && !canBuild && GetComponent<pickUpMoney>().money >= 50)
        {
            name = "Tower Buffer";
            type = 4;
            path = "/Tower Buffer(Clone)/Runestone";
            price = 50;

            canBuild = true;
            StartCoroutine(invokTower());
        }
        else if (Input.GetKey(KeyCode.Alpha6) && !canBuild && GetComponent<pickUpMoney>().money >= 50)
        {
            name = "Stun Trap";
            type = 5;
            path = "/Stun Trap(Clone)/tap";
            price = 50;
            decal = -17;

            canBuild = true;
            StartCoroutine(invokTower());
        }
        else if(Input.GetKey(KeyCode.Alpha7) && !canBuild && GetComponent<pickUpMoney>().money >= 0)
        {
            name = "Frozen Trap";
            type = 6;
            path = "/Frozen Trap(Clone)/tap";
            price = 0;
            decal = 0;

            canBuild = true;
            StartCoroutine(invokTower());
        }

        //l'objet suit la souris
        if (canBuild) //Lorsque l'une des tour a été selectionné
        {
            var player = GameObject.Find("Player");
            var tour = GameObject.Find(name + "(Clone)"); //Ajout du mot "(Clone)" pour differentier la tour des autres tour deja construite

            double cosAngle = Mathf.Cos(transform.eulerAngles.y * Mathf.PI / 180); //Permet de maintenir la tour devant meme lors de rotation
            double sinAngle = Mathf.Sin(transform.eulerAngles.y * Mathf.PI / 180);

            if(name == "Canon Tower" || name == "Mage Tower")
            {
                attackScript = tour.GetComponent<Attack>();
                attackScript.enabled = false; //Eteint le script "Attck" sur la tour

                //tour.GetComponent<CanBuildHere>().enabled = true;
            }


            Vector3 playerPos = player.transform.position; //Position actuelle du joueur
            Vector3 towerPos = tour.transform.position; //Position actuelle de la tour

            tour.transform.rotation = player.transform.rotation;
            if(name != "Frozen Trap")
                tour.GetComponent<BoxCollider>().isTrigger = true; //Desactivation du collider
            if (name == "Canon Tower" || name == "Mage Tower" || name == "Fire Tower" || name == "Tower Buffer")
            {
                tour.GetComponent<SphereCollider>().enabled = false;
            }
            tour.transform.position = new Vector3(playerPos.x + 20 * (float)sinAngle, 0 + decal, playerPos.z + 20 * (float)cosAngle); //Modifie la position de la tour en fonction de la pos du joueur

            
        }


        //l'objet est construit pour de vrai en jeu 
        if ((isBuildable && canBuild && Input.GetMouseButton(0)) || Input.GetMouseButton(1))
        {
            //Déclaration de variable
            var player = GameObject.Find("Player");
            var tour = GameObject.Find(name + "(Clone)");

            if (Input.GetMouseButton(1) && tour != null) //clic droit
            {
                if (tour != null)
                {
                    Destroy(tour); //detruit la tour
                    canBuild = false; //on ne peut plus poser de tour il faut re-choisir une tour
                    isBuildable = true;
                }
            }
            if (tour != null)
            {
                Vector3 playerPos = player.transform.position;
                Vector3 towerPos = tour.transform.position;



                if (name == "Canon Tower" || name == "Mage Tower" || name == "Fire Tower" || name == "Tower Buffer")
                {
                    //tour.GetComponent<CanBuildHere>().enabled = false;
                    if (name == "Canon Tower" || name == "Mage Tower")
                        attackScript.enabled = true; //Le script d'attack est désormais activé
                    tour.GetComponent<CanBuildHere>().enabled = false;
                }
            }
           
            if (Input.GetMouseButton(0)) //clic gauche
            {
                GetComponent<pickUpMoney>().money -= price;
                print(GetComponent<pickUpMoney>().money);
                //réactive le collider de la tour
                if(name != "Stun Trap" && name != "Frozen Trap")
                    tour.GetComponent<BoxCollider>().isTrigger = false;
                if (name == "Canon Tower" || name == "Mage Tower" || name == "Fire Tower" || name =="Tower Buffer")
                {
                    tour.GetComponent<SphereCollider>().enabled = true;
                    tour.transform.GetChild(2).GetComponent<BoxCollider>().enabled = true;
                }
                if(name == "Tower Buffer")
                {
                    tour.transform.GetChild(0).gameObject.SetActive(true);
                }
                //remet les couleurs de la tour
                var walls = GameObject.Find(path);
                if(name != "Frozen Trap")
                    walls.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                canBuild = false; //on ne peut plus poser de tour il faut re-choisir une tour
                isBuildable = true;

                GameObject.Find(name + "(Clone)").name = name + "(Build)"; //On change le nom de la tour avec "(Build)" pour la differentier des autres tours
                decal = 0;
            }
        }
    }


    //Clone l'objet voulu
    IEnumerator invokTower()
    {
        Instantiate(GameObject.Find(name), new Vector3(transform.position.x, transform.position.y + decal, transform.position.z + 20), Quaternion.identity).name = name + "(Clone)"; //créer l'objet (la tour dans ce cas)
        CancelInvoke(); //arrete la creation de tour
        if (name == "Canon Tower" || name == "Mage Tower" || name == "Fire Tower" || name == "Tower Buffer")
        {
            GameObject.Find(name + "(Clone)").GetComponent<CanBuildHere>().enabled = true;
        }
        GameObject.Find(path).GetComponent<MeshRenderer>().material.color = new Color(0.2f, 1.0f, 0.2f, 1.0f); //La tour devient verte

        yield return new WaitForSeconds(0); //temps avant d'effectuer les instructions précedente (0 sec dans ce cas)
    }
    /*void OnTriggerEnter(Collider other) //Ca ca marche pas
    {
        if (other.tag == "Tower" && other.tag == "NoBuild")
        {
            GameObject.Find(path).GetComponent<MeshRenderer>().material.color = new Color(1.0f, 0.2f, 0.2f, 1.0f);
            print(other.tag);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Tower")
        {
            GameObject.Find(path).GetComponent<MeshRenderer>().material.color = new Color(0.2f, 1.0f, 0.2f, 1.0f);
        }
    }*/
}
