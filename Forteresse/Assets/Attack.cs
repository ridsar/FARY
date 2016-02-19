using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    public int damage = 5;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        InvokeRepeating("attack", 0, 2);
	}

    void attack()
    {
        RaycastHit hit;
        Vector3 p1 = transform.position;
        float distance = 0f;

        if (Physics.SphereCast(p1, 10f, transform.forward, out hit, 10f))
        {
            damagePlayer _health = new damagePlayer(0);
            distance = hit.distance;
            if (hit.collider.tag == "Enemy")
            {
                int health = _health.getHealth();

                health -= damage;
            }

        }
    }
}
