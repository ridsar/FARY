using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CanBuildHereRes : NetworkBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider other)
    {
        if (gameObject.GetComponent<CanBuildHereRes>().isActiveAndEnabled == true)
        {
            Physics.IgnoreCollision(gameObject.GetComponent<SphereCollider>(), other);

            if (other.tag == "NoBuild")
            {
                transform.GetChild(1).GetComponent<MeshRenderer>().material.color = new Color(1.0f, 0.2f, 0.2f, 1.0f);
                GameObject.Find("Player").GetComponent<BuildRes>().Buildable = false;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (gameObject.GetComponent<CanBuildHereRes>().isActiveAndEnabled == true)
        {
            if (other.tag == "NoBuild")
            {
                transform.GetChild(1).GetComponent<MeshRenderer>().material.color = new Color(0.2f, 1.0f, 0.2f, 1.0f);
                GameObject.Find("Player").GetComponent<BuildRes>().Buildable = true;
            }
        }
    }
}
