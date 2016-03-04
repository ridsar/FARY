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

    public int attackSpeed;

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
            parent = "/Mage Tower(Build)/";
            scale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        else if (parentName == "Canon Tower(Build)" || parentName == "Canon Tower(Clone)")
        {
            name = "Canon Projectile";
            parent = "/Canon Tower(Build)/";
            scale = new Vector3(1, 1, 1);
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

            GameObject projectile = GameObject.Find(parent + name);
            Vector3 up = new Vector3(0, 12, 0);

            var myNewSmoke = Instantiate(projectile, gameObject.transform.position + up, Quaternion.identity).name = name + "(Clone)";
            GameObject.Find(myNewSmoke).transform.parent = gameObject.transform;

            monScript = GameObject.Find(name + "(Clone)").GetComponent<move>();
            monScript.enabled = true;

            destroy = GameObject.Find(name + "(Clone)").GetComponent<selfDestruct>();
            destroy.enabled = true;
            CancelInvoke();
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
