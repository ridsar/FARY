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

    private Vector3 scale;


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
            scale = new Vector3(1, 1, 1);
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
    }

    // Update is called once per frame

    void Update()
    {
    }

    void OnTriggerStay(Collider other) //Lorsqu'il y a des enemies dans le collider 
    {                                  //Tout les objets vont être testé (enemie ou pas)
        if(other.tag == "Enemy") 
        {
            check = check && false; //un enemie est présent -> check sera false, la tour attaquera
        }
        else
        {
            check = check && true; //l'objet testé n'est pas un enemie, cela depend donc des autres objets
        }       
    }

    void OnTriggerEnter(Collider other) //Lorsqu'un enemie entre en collision check est sur false et donc la tour attaque
    { 
        if (other.tag == "Enemy" && check)
        {
            check = false;
            StartCoroutine(move());
        }
    }

    void OnTriggerExit(Collider other) //Lorsqu'un enemie sort de collision check est sur true et donc la tour n'attaque pas
    {
        if (other.tag == "Enemy")
        {
            check = true;
        }
    }
    IEnumerator move()
    {
        while (!check)
        {
            GameObject projectile = null;
            GameObject newProj = null;
            if (name == "Canon Projectile" || name == "Mage Projectile")
            {
                projectile = gameObject.transform.GetChild(index).gameObject;
            }
            else if (name == "Fire Projectile")
            {
                projectile = gameObject.transform.GetChild(index).GetChild(0).gameObject;
            }
            newProj = Instantiate(projectile, gameObject.transform.GetChild(0).position, Quaternion.identity) as GameObject; //Créer l'objet (porjectile)
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
            if (name ==  "Canon Projectile" || name == "Mage Projectile")
            {
                newProj.transform.parent = gameObject.transform; //fait en sorte que la tour soit le parent du projectile
                newProj.GetComponent<move>().enabled = true;
                newProj.GetComponent<selfDestruct>().enabled = true;
            }

            newProj.name = name + "(Build)"; //Passage a l'etat "(Build)"

            check = true;
            yield return new WaitForSeconds(attackSpeed); //Le temps entre les activations (la vitesse d'attaque des tours)
        }
    }
}
