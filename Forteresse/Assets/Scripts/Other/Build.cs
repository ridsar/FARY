using UnityEngine;
using System.Collections;


public class Build : MonoBehaviour
{
    public GameObject[] Tower;
    private Vector3 spawnPoints;
    bool canBuild = false;
    string name = "";
    int type;
    Attack attackScript;

    void Start()
    {

    }
    void Update()
    {

        this.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);

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
        if (Input.GetKey(KeyCode.Alpha1) && !canBuild)
        {
            name = "Mage Tower"; //Paramètre pour la tour a instancier
            type = 0;

            canBuild = true; //variable disant si je peux poser une tour ou pas
            StartCoroutine(invokTower()); //Lance la Coroutine qui va instancier la tour
        }

        if (Input.GetKey(KeyCode.Alpha2) && !canBuild)
        {
            name = "Canon Tower"; //Paramètre pour la tour a instancier
            type = 1;

            canBuild = true; //variable disant si je peux poser une tour ou pas
            StartCoroutine(invokTower()); //Lance la Coroutine qui va instancier la tour
        }

        //l'objet suit la souris
        if (canBuild) //Lorsque l'une des tour a été selectionné
        {
            var player = GameObject.Find("Player");
            var tour = GameObject.Find(name + "(Clone)"); //Ajout du mot "(Clone)" pour differentier la tour des autres tour deja construite

            double cosAngle = Mathf.Cos(transform.eulerAngles.y * Mathf.PI / 180); //Permet de maintenir la tour devant meme lors de rotation
            double sinAngle = Mathf.Sin(transform.eulerAngles.y * Mathf.PI / 180);

            attackScript = tour.GetComponent<Attack>();
            attackScript.enabled = false; //Eteint le script "Attck" sur la tour

            Vector3 playerPos = player.transform.position; //Position actuelle du joueur
            Vector3 towerPos = tour.transform.position; //Position actuelle de la tour

            tour.GetComponent<Collider>().enabled = false; //Desactivation du collider

            tour.transform.position = new Vector3(playerPos.x + 20 * (float)sinAngle, 0, playerPos.z + 20 * (float)cosAngle); //Modifie la position de la tour en fonction de la pos du joueur


            //Change la couleur de la tour, si elle est posable ou pas

            var walls = GameObject.Find("/" + name + "(Clone)/Walls"); //On recupère les murs de la tour

            if (playerPos.x - towerPos.x > 50 || playerPos.x - towerPos.x < -50 || playerPos.z - towerPos.z > 50 || playerPos.z - towerPos.z < -50) //Actuellement useless
            {
                walls.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 0.2f, 0.2f, 1.0f); //La tour devient verte
            }
            else
                walls.GetComponent<MeshRenderer>().material.color = new Color(0.2f, 1.0f, 0.2f, 1.0f); //La tour devient rouge


        }


        //l'objet est construit pour de vrai en jeu 
        if (canBuild && (Input.GetMouseButton(1) || Input.GetMouseButton(0)))
        {
            //Déclaration de variable
            var player = GameObject.Find("Player");
            var tour = GameObject.Find(name + "(Clone)");

            Vector3 playerPos = player.transform.position;
            Vector3 towerPos = tour.transform.position;

            attackScript.enabled = true; //Le script d'attack est désormais activé

            if (Input.GetMouseButton(1)) //clic droit
            {
                Destroy(tour); //detruit la tour
                canBuild = false; //on ne peut plus poser de tour il faut re-choisir une tour
            }
            if (Input.GetMouseButton(0)) //clic gauche
            {
                //remet les couleurs de la tour
                var walls = GameObject.Find("/" + name + "(Clone)/Walls");
                walls.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

                //réactive le collider de la tour
                tour.GetComponent<Collider>().enabled = true;

                canBuild = false; //on ne peut plus poser de tour il faut re-choisir une tour

                GameObject.Find(name + "(Clone)").name = name + "(Build)"; //On change le nom de la tour avec "(Build)" pour la differentier des autres tours
            }
        }
    }


    //Clone l'objet voulu
    IEnumerator invokTower()
    {
        Instantiate(Tower[type], new Vector3(transform.position.x, transform.position.y, transform.position.z + 20), Quaternion.identity).name = name + "(Clone)"; //créer l'objet (la tour dans ce cas)
        CancelInvoke(); //arrete la creation de tour
        yield return new WaitForSeconds(0); //temps avant d'effectuer les instructions précedente (0 sec dans ce cas)
    }
    void OnTriggerStay(Collider other) //Ca ca marche pas
    {
        if (other.tag == "Tower" && GameObject.Find(name + "(Clone)"))
        {
            GameObject.Find(name + "(Clone)/Walls").GetComponent<MeshRenderer>().material.color = new Color(1.0f, 0.2f, 0.2f, 1.0f);
        }
    }
}
