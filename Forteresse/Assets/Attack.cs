using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    public int damage = 5;
    public GameObject[] Proj;
    private Vector3 sommet;

    // Use this for initialization
    void Start ()
    {
	
	}

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("attack", 0, 300);
               
    }
    void attack()
    {
        Proj = GameObject.FindGameObjectsWithTag("Damage");

        RaycastHit hit;
        Vector3 p1 = transform.position;

        if (Physics.SphereCast(p1, 10f, transform.forward, out hit, 10f) && hit.transform.tag == "Enemy")
        {
            sommet = transform.position;
            print(hit.collider);
            Vector3 direction = hit.transform.position;
            StartCoroutine(spawnProjectile(sommet, direction));
            Destroy(GameObject.Find("Projectile(Clone)"));
            
        }
    }

    IEnumerator spawnProjectile(Vector3 sommet, Vector3 direction)
    {
        sommet += new Vector3(0, 2, 0);
        Instantiate(Proj[UnityEngine.Random.Range(0, 0)], sommet, Quaternion.identity).name = "Projectile(Clone)";
        GameObject.Find("Projectile(Clone)").transform.position = Vector3.MoveTowards(transform.position, direction, 0);
        CancelInvoke();
        yield return new WaitForSeconds(0);

    }
}
