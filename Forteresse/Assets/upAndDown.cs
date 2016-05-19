using UnityEngine;
using System.Collections;

public class upAndDown : MonoBehaviour {

    bool check;
    Transform child;

	// Use this for initialization
	void Start ()
    {
        child = transform.GetChild(0).transform;
    }

    // Update is called once per frame
    void Update ()
    {
        if (!check)
        {
            child.localPosition = Vector3.Lerp(child.localPosition, new Vector3(0, 0.3f, 0), 0.1f);
        }
	}
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Enemy")
        {
            check = true;
            child.localPosition = Vector3.Lerp(child.localPosition, new Vector3(0, 0.8f, 0), 0.2f);
        }
        else
        {
            check = check || false;
        }   
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Enemy")
        {
            check = false;
        }
    }
}
