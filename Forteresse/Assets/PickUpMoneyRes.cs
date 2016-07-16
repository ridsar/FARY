using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickUpMoneyRes : MonoBehaviour {

    public int money = 0;
    public Text CountMoney;
    // Use this for initialization
    void Start()
    {
        CountMoney = GameObject.Find("GoldText").GetComponent<Text>(); 
    }

    // Update is called once per frame
    void Update()
    {
        CountMoney.text = money.ToString(); //R
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Money")
        {
            if (other.gameObject.name == "Coin(Clone)")
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
