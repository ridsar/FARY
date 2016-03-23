using UnityEngine;
using System.Collections;

public class AttackPlayer : MonoBehaviour {

    BoxCollider arme;

    // Use this for initialization
    void Start()
    {
        arme = gameObject.transform.FindChild("Player dmg").GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            StartCoroutine(attack());
            StopCoroutine(attack());
        }
        
    }
    IEnumerator attack()
    {
        arme.enabled = true;
        
        yield return 60f;

        arme.enabled = false;
    }
}
