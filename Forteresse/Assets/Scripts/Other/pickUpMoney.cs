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
            if(other.gameObject.name == "Coin(Clone)")
            {
                Destroy(other.gameObject);
                ++money;
            }
            else if (other.transform.name == "Ignot(Clone)")
            {
                Destroy(other.gameObject);
                money += 5;
            }
            print(money);
        }
    }
}
