using UnityEngine;
using System.Collections;

public class FireEnemyAttack : MonoBehaviour {


    public GameObject fire;
    bool canAttack = true;
    float time = 0f;
    GameObject firebreath;

    // Use this for initialization
    void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        print(time);
        if (time > 0)
            time -= 1 * Time.deltaTime;

        if (time <= 0 && !canAttack)
        {
            firebreath = Instantiate(fire) as GameObject;
            firebreath.transform.parent = transform;
            firebreath.transform.localPosition = new Vector3(0f, 2.30f, 6f);
            firebreath.transform.rotation = new Quaternion(0f, 0, 0, 0);
            firebreath.SetActive(true);
            time = 10f;
        }
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Crystal")
        {
            if (canAttack)
            {
                canAttack = false;
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Crystal")
        {
            canAttack = canAttack && false;
        }
        else
            canAttack = canAttack && true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Crystal")
        {
            canAttack = true;
        }
    }
}
