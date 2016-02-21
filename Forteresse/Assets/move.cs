using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {


    private Transform target = null;

    // Use this for initialization
    void Start ()
    {

	}

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        transform.LookAt(target);

        float distance = Vector3.Distance(transform.parent.position, target.position);
        bool tooClose = distance < 0;

        Vector3 direction = tooClose ? Vector3.back : Vector3.forward;
        transform.Translate(direction * Time.deltaTime * 10);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
            target = other.transform;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
            target = null;
    }
}
