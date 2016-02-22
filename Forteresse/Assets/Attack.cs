using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    public int damage = 5;

    public GameObject[] Proj;

    private Vector3 sommet;

    Collider colli;

    move monScript;

    selfDestruct destroy;

    int n = 0;

    bool check = true;

    public int attackSpeed;


    // Use this for initialization
    void Start ()
    {
	}

    // Update is called once per frame
        
    void Update()
    {
        if (GameObject.Find("Projectile(Clone)"))
        {
            GameObject.Find("Projectile(Clone)").transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            GameObject.Find("Projectile(Clone)").transform.name = "Projectile(Build)";
        }
        if (Input.GetKey(KeyCode.N))
        {
            StopCoroutine(move());
        }
    }
    void Call()
    {

    }
    IEnumerator move()
    {
        while (!check)
        {
            GameObject projectile = GameObject.Find("Projectile");

            var myNewSmoke = Instantiate(projectile, projectile.transform.position, Quaternion.identity).name = "Projectile(Clone)";
            GameObject.Find(myNewSmoke).transform.parent = gameObject.transform;
            monScript = GameObject.Find("Projectile(Clone)").GetComponent<move>();
            monScript.enabled = true;
            destroy = GameObject.Find("Projectile(Clone)").GetComponent<selfDestruct>();
            destroy.enabled = true;
            yield return new WaitForSeconds(attackSpeed);
        }       
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (n == 0 && check)
            {
                check = false;
                StartCoroutine(move());
            }
            ++n;
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            --n;
            if ( n <= 0 && !check)
            {
                check = true;
            }
        }        
    }
}
