using UnityEngine;
using System.Collections;

public class CanBuildHere : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other) //Ca ca marche pas
    {
        if ((other.tag == "Tower" || other.tag == "NoBuild"))
        {
            transform.GetChild(1).GetComponent<MeshRenderer>().material.color = new Color(1.0f, 0.2f, 0.2f, 1.0f);
            GameObject.Find("Player").GetComponent<Build>().isBuildable = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Tower" || other.tag == "NoBuild")
        {
            transform.GetChild(1).GetComponent<MeshRenderer>().material.color = new Color(0.2f, 1.0f, 0.2f, 1.0f);
            GameObject.Find("Player").GetComponent<Build>().isBuildable = true;
        }
    }
}
