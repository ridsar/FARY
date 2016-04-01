using UnityEngine;
using System.Collections;

public class pickUpMoney : MonoBehaviour {

    int money = 0;
	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Money")
        {
            Destroy(other.gameObject);
            ++money;
            print(money);
        }
    }
}
