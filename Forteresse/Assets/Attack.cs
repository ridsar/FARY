using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    public int damage = 5;

    public GameObject[] Proj;

    private Vector3 sommet;

    float startTime = 0.0f;

    private float currentLerpTime = 0;

    private float lerpTime = 3;

    // Use this for initialization
    void Start ()
    {
	    
	}

    // Update is called once per frame
    void Update()
    {     

        /*Proj = GameObject.FindGameObjectsWithTag("Damage");

        RaycastHit hit;
        Vector3 p1 = transform.position;

        if (Physics.CheckSphere(p1, 10f) && Physics.SphereCast(p1, 10f, transform.forward, out hit, 10f) && hit.transform.tag == "Enemy")
        {
            sommet = transform.position;
            sommet += new Vector3(0, 10, 0);

            print(hit.collider);
            Vector3 direction = hit.transform.position;

            Instantiate(Proj[UnityEngine.Random.Range(0, Proj.Length - 1)], sommet, Quaternion.identity).name = "Projectile(Clone)";
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime >= lerpTime)
            {
                currentLerpTime = lerpTime;
            }
            GameObject.Find("Projectile(Clone)").transform.position = Vector3.Lerp(GameObject.Find("Projectile(Clone)").transform.position, hit.transform.position, 5);
            CancelInvoke();
        }*/
    }   
    void OnTriggerEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Vector3 toto = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
        }
    }
}
