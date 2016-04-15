using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class playerHealth : MonoBehaviour
{

    public int Health;
    public Slider PlayerHealthBar; //R

    void Start()
    {
        print(Health);
    }

    void Update()
    {
        if (Health <= 0)
        {
            transform.position = new Vector3(443, 0, 436);
            GetComponent<pickUpMoney>().money -= 50;
            if (GetComponent<pickUpMoney>().money < 0)
                GetComponent<pickUpMoney>().money = 0;
            print(GetComponent<pickUpMoney>().money);
            Health = 100;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DamageEnemy")
        {
            switch (other.name)
            {
                case "Troll dmg":
                    {
                        Health -= 20;
                        if (PlayerHealthBar.value >= (float)(1 / 5))   //R
                        {                                            
                            PlayerHealthBar.value -= (float)(1 / 5); //R
                        }
                    }
                    break;
                case "Goblin dmg":
                    {
                        Health -= 10;
                        if (PlayerHealthBar.value >= (float)(1 / 10))   //R
                        {
                            PlayerHealthBar.value -= (float)(1 / 10); //R
                        }
                    }
                    break;
                case "Skeleton dmg":
                    {
                        Health -= 20;
                        if (PlayerHealthBar.value >= (float)(1 / 5))   //R
                        {
                            PlayerHealthBar.value -= (float)(1 / 5); //R
                        }
                    }
                    break;
            }
            print(Health);
        }
    }
    void OnTriggerStay(Collider other)
    {
        
    }
}
