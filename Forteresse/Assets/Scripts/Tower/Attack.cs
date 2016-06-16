using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{

    public int damage = 5;

    public GameObject[] Proj;

    private Vector3 sommet;

    Collider colli;

    public bool check = true;

    private float attackSpeed;

    private string name;
    private string parentName;
    private string child;
    private int index;
    private float buff = 1;
    private Vector3 scale;
    private float time;


    // Use this for initialization
    void Start()
    {
        parentName = transform.name;

        //Initialisation des paramètres en fonction de la tour
        if (parentName == "Mage Tower(Build)" || parentName == "Mage Tower(Clone)")
        {
            name = "Mage Projectile";
            child = "/Mage Tower(Build)/Mage Projectile";
            scale = new Vector3(1f, 1f, 1f);
            index = 0;
            attackSpeed = 2;
        }
        else if (parentName == "Canon Tower(Build)" || parentName == "Canon Tower(Clone)")
        {
            name = "Canon Projectile";
            child = "/Canon Tower(Build)/Canon Projectile";
            scale = new Vector3(1.5f, 1.2f, 1.5f);
            index = 0;
            attackSpeed = 3.5f;
        }
        else if (parentName == "Fire Tower(Clone)" || parentName == "Fire Tower(Build)")
        {
            name = "Fire Projectile";
            child = "/Fire Tower(Build)/Fire Projectile";
            scale = new Vector3(1, 1, 1);
            index = 0;
            attackSpeed = 2f;
        }
        else if (parentName == "Frozen Tower(Clone)" || parentName == "Frozen Tower(Build)")
        {
            name = "Frozen Projectile";
            child = "/Frozen Tower(Build)/Frozen Projectile";
            scale = new Vector3(1, 1, 1);
            index = 0;
            attackSpeed = 1f;
        }
        time = attackSpeed / buff;
    }

    // Update is called once per frame

    void Update()
    {
        if (time > 0)
            time -= 1 * Time.deltaTime;
        else
            time = 0;
        if (!check && time == 0)
        {
            GameObject projectile = null;
            GameObject newProj = null;

            if (name == "Canon Projectile" || name == "Mage Projectile" || name == "Frozen Projectile")
            {
                projectile = gameObject.transform.GetChild(index).gameObject;
            }
            else if (name == "Fire Projectile")
            {
                projectile = gameObject.transform.GetChild(index).GetChild(0).gameObject;
            }

            newProj = Instantiate(projectile, gameObject.transform.GetChild(0).position, Quaternion.identity) as GameObject; //Créer l'objet (porjectile)
            newProj.SetActive(true);
            CancelInvoke(); //arrete la création d'objet
            newProj.name = name + "(Clone)"; //ajout de "(Clone)" pour le differencier des autres projectiles 

            newProj.transform.localScale = scale; //adapte la taille du projectile en fonction de la tour
            newProj.transform.parent = gameObject.transform; //fait en sorte que la tour soit le parent du projectile

            if (name == "Fire Projectile")
            {
                newProj.transform.parent = gameObject.transform.GetChild(0); //fait en sorte que la tour soit le parent du projectile
                newProj.SetActive(true);
            }
            //activation des scripts
            if ((name == "Canon Projectile" || name == "Mage Projectile" || name == "Frozen Projectile") && newProj != null)
            {
                newProj.transform.parent = gameObject.transform; //fait en sorte que la tour soit le parent du projectile
                newProj.GetComponent<move>().enabled = true;
                newProj.GetComponent<selfDestruct>().enabled = true;
                newProj.transform.GetChild(1).gameObject.SetActive(true);
            }
            if(name == "Frozen Projectile")
            {
                newProj.GetComponent<Gem>().enabled = false;
            }
                
            newProj.name = name + "(Build)"; //Passage a l'etat "(Build)"
            time = attackSpeed;
        }
    }

    void OnTriggerStay(Collider other) //Lorsqu'il y a des enemies dans le collider 
    {                                  //Tout les objets vont être testé (enemie ou pas)
        if (other.tag == "Enemy")
        {
            check = check && false; //un enemie est présent -> check sera false, la tour attaquera
        }
        else
        {
            check = check && true; //l'objet testé n'est pas un enemie, cela depend donc des autres objets
        }
        if (other.name == "Tower Buffer(Build)")
        {
            buff = 2;
        }
        if (other.name == "Tower Buffer(Clone)")
        {
            if (transform.name == "Frozen Tower(Build)")
                transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(1).GetComponent<MeshRenderer>().material.color = new Color(0.2f, 0.2f, 1.0f, 1.0f);
        }
        if (other.name == "Tower Buffer(Build)" && transform.name != "Mage Tower(Clone)" && transform.name != "Canon Tower(Clone)" && transform.name != "Frozen Tower(Clone)")
        {
            transform.GetChild(3).gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other) //Lorsqu'un enemie entre en collision check est sur false et donc la tour attaque
    {
        if (other.tag == "Enemy" && check)
        {
            check = false;
        }
        if (other.name == "Tower Buffer(Build)" && transform.name != "Mage Tower(Clone)" && transform.name != "Canon Tower(Clone)" && transform.name != "Frozen Tower(Clone)")
        {
            transform.GetChild(3).gameObject.SetActive(true);
            transform.GetChild(1).GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            attackSpeed = buff;
        }
    }
    void OnTriggerExit(Collider other) //Lorsqu'un enemie sort de collision check est sur true et donc la tour n'attaque pas
    {
        if (other.tag == "Enemy")
        {
            check = true;
        }
        if (other.name == "Tower Buffer(Clone)")
        {
            if (transform.name == "Frozen Tower(Build)")
                transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(1).GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        if (other.name == "Tower Buffer(Build)")
        {
            buff = 1;
        }
    }
}
