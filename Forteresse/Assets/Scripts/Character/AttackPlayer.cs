using UnityEngine;
using System.Collections;

public class AttackPlayer : MonoBehaviour {

    BoxCollider arme;
    float time = 0f;

    // Use this for initialization
    void Start()
    {
        arme = gameObject.transform.FindChild("Player dmg").GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0)
            time -= 1 * Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && time <= 0)
        {
            time = 3;
            StartCoroutine(attack());
            StopCoroutine(attack());
        }  
    }
    IEnumerator attack()
    {
        arme.enabled = true;

        yield return new WaitForSeconds(0.5f);

        arme.enabled = false;
    }
}
