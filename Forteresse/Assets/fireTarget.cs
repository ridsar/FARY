using UnityEngine;
using System.Collections;

public class fireTarget : MonoBehaviour
{

    private Transform target = null;
    Vector3 targetPos;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        else if (target != null)
        {
           targetPos = new Vector3(target.position.x, transform.position.y, target.position.z);
           this.transform.LookAt(targetPos);
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
