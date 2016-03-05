using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {


    private Transform target = null;
    string parentName;
    string name;

    // Use this for initialization
    void Start ()
    {
        parentName = transform.parent.name;

        if(parentName == "Mage Tower(Build)" || parentName == "Mage Tower(Clone)")
        {
            name = "Mage Projectile(Build)";
        }
        else if(parentName == "Canon Tower(Build)" || parentName == "Canon Tower(Clone)")
        {
            name = "Canon Projectile(Build)";
        }
	}

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        
        transform.LookAt(target);
        if(transform.parent.name == "Canon Tower(Build)")
            transform.parent.LookAt(target);

        float distance = Vector3.Distance(transform.parent.position, target.position);
        bool tooClose = distance < 0;

        Vector3 direction = tooClose ? Vector3.back : Vector3.forward;
        transform.Translate(direction * Time.deltaTime * 50);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
            target = other.transform;
    }

    void OnTriggerExit(Collider other)
    {        
        if (other.tag == "Enemy")
        {
            Destroy(GameObject.Find(name));
            target = null;
        }
    }
}
