using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

    private Transform target = null;
    Vector3 targetPos;

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (target == null)
            return;
        else if (target != null)
        {
            if (transform.FindChild("Tower_Top"))
            {
                targetPos = new Vector3(target.position.x, this.transform.FindChild("Tower_Top").position.y, target.position.z);
                this.transform.FindChild("Tower_Top").LookAt(targetPos);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            target = null;
        }
    }
        void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy" && target == null)
            target = other.transform;
    }

    
    
}
