using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{

    public int damage = 5;

    public GameObject[] Proj;

    private Vector3 sommet;

    Collider colli;

    move monScript;

    selfDestruct destroy;

    bool check = true;

    private float attackSpeed;

    private string name;
    private string parentName;
    private string parent;

    private Vector3 scale;


    // Use this for initialization
    void Start()
    {
        parentName = transform.name;

        if (parentName == "Mage Tower(Build)" || parentName == "Mage Tower(Clone)")
        {
            name = "Mage Projectile";
            parent = "/Mage Tower(Build)/Mage Projectile";
            scale = new Vector3(0.1f, 0.1f, 0.1f);
            attackSpeed = 2;
        }
        else if (parentName == "Canon Tower(Build)" || parentName == "Canon Tower(Clone)")
        {
            name = "Canon Projectile";
            parent = "/Canon Tower(Build)/Canon Projectile";
            scale = new Vector3(1, 1, 1);
            attackSpeed = 3.5f;
        }
    }

    // Update is called once per frame

    void Update()
    {

        if (GameObject.Find(name + "(Clone)"))
        {
            GameObject.Find(name + "(Clone)").transform.localScale = scale;
            GameObject.Find(name + "(Clone)").transform.name = name + "(Build)";
        }
    }

    IEnumerator move()
    {
        while (!check)
        {

            GameObject projectile = GameObject.Find(parent);
            var myNewSmoke = Instantiate(projectile, gameObject.transform.GetChild(0).position, Quaternion.identity).name = name + "(Clone)";
            CancelInvoke();
            GameObject.Find(myNewSmoke).transform.parent = gameObject.transform;

            monScript = GameObject.Find(name + "(Clone)").GetComponent<move>();
            monScript.enabled = true;

            destroy = GameObject.Find(name + "(Clone)").GetComponent<selfDestruct>();
            destroy.enabled = true;
            yield return new WaitForSeconds(attackSpeed);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Enemy")
        {
            check = check && false;           
        }
        else
        {
            check = check && true;
        }       
    }

    void OnTriggerEnter(Collider other)
    { 
        if (other.tag == "Enemy" && check)
        {
            check = false;
            StartCoroutine(move());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            check = true;
        }
    }
}
