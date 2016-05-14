using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class playerHealth : MonoBehaviour
{

    public int Health;
    public Slider PlayerHealthBar; //R

    int maxHealth;

    void Start()
    {
        print(Health);
        maxHealth = Health;
    }

    void Update()
    {
        if (Health <= 0)
        {
            PlayerHealthBar.value = 0f; //R
            transform.position = new Vector3(443, 0, 436);
            GetComponent<pickUpMoney>().money -= 50;

            if (GetComponent<pickUpMoney>().money < 0)
                GetComponent<pickUpMoney>().money = 0;

            print(GetComponent<pickUpMoney>().money);
            Health = maxHealth;
            PlayerHealthBar.value = 1f; //R
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DamageEnemy")
        {
            switch (other.name)
            {
                case "Troll dmg":
                    Health -= 20;
                    if (PlayerHealthBar.value > 20f / maxHealth)   //R
                    {
                        PlayerHealthBar.value -= 20f / maxHealth; //R
                    }
                    break;
                case "Goblin dmg":
                    Health -= 10;
                    if (PlayerHealthBar.value >= 10f / maxHealth)   //R
                    {
                        PlayerHealthBar.value -= 10f / maxHealth; //R
                    }
                    break;
                case "Skeleton dmg":
                    Health -= 20;
                    if (PlayerHealthBar.value >= 20f / maxHealth)   //R
                    {
                        PlayerHealthBar.value -= 20f / maxHealth; //R
                    }
                    break;
                case "Arrow(Build)":
                    Health -= 10;
                    Destroy(other);
                    if(PlayerHealthBar.value >= 10f / maxHealth)
                    {
                        PlayerHealthBar.value -= 10f / maxHealth;
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
