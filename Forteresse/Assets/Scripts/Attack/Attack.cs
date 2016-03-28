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
            attackSpeed = 2;
        }
        else if (parentName == "Canon Tower(Build)" || parentName == "Canon Tower(Clone)")
        {
            name = "Canon Projectile";
            child = "/Canon Tower(Build)/Canon Projectile";
            scale = new Vector3(1, 1, 1);
            attackSpeed = 3.5f;
        }
    }

    // Update is called once per frame

    void Update()
    {

    }

    IEnumerator move()
    {
        while (!check)
        {
            GameObject projectile = GameObject.Find(child);
            var newProj = Instantiate(projectile, gameObject.transform.GetChild(0).position, Quaternion.identity); //Créer l'objet (porjectile)
            CancelInvoke(); //arrete la création d'objet
            newProj.name = name + "(Clone)"; //ajout de "(Clone)" pour le differencier des autres projectiles 

            GameObject projTemp = GameObject.Find(newProj.name); //Le projectile

            projTemp.transform.localScale = scale; //adapte la taille du projectile en fonction de la tour
            projTemp.transform.parent = gameObject.transform; //fait en sorte que la tour soit le parent du projectile

            //activation des scripts
            projTemp.GetComponent<move>().enabled = true;
            projTemp.GetComponent<selfDestruct>().enabled = true;

            projTemp.name = name + "(Build)"; //Passage a l'etat "(Build)"

            yield return new WaitForSeconds(attackSpeed); //Le temps entre les activations (la vitesse d'attaque des tours)
        }
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
}
