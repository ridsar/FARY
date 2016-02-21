using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    public int damage = 5;

    public GameObject[] Proj;

    private Vector3 sommet;

    float startTime = 0.0f;

    private float currentLerpTime = 0;

    private float lerpTime = 3;

    Collider colli;

    move monScript;


    // Use this for initialization
    void Start ()
    {
        StartCoroutine(move());
	}

    // Update is called once per frame
        
    void Update()
    {
        if (GameObject.Find("Projectile(Clone)"))
        {
            GameObject.Find("Projectile(Clone)").transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            GameObject.Find("Projectile(Clone)").transform.name = "Projectile(Build)";
        }
    }
    void Call()
    {

    }
    IEnumerator move()
    {
        while (true)
        {
            GameObject projectile = GameObject.Find("Projectile");

            var myNewSmoke = Instantiate(projectile, projectile.transform.position, Quaternion.identity).name = "Projectile(Clone)";
            GameObject.Find(myNewSmoke).transform.parent = gameObject.transform;
            monScript = GameObject.Find("Projectile(Clone)").GetComponent<move>();
            monScript.enabled = true;
            yield return new WaitForSeconds(3);
        }       
    }
}
