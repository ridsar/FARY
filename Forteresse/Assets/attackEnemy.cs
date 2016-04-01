using UnityEngine;
using System.Collections;

public class attackEnemy : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collision other)
    {
        float dist = Vector3.Distance(transform.position, other.transform.position);
        if (dist < 10)
        {
            StartCoroutine(autoAttack());
        }
    }
    IEnumerator autoAttack()
    {

        yield return new WaitForSeconds(0.3f);
    }
}
