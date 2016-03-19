using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class damagePlayer : MonoBehaviour
{
    public int playerHealth = 100;
    int dead = 0;
    public Slider PlayerHealthBar; //R

    public int getDead()
    {
        return dead;
    }

    void Start()
    {
        print(playerHealth);
    }

    void Update()
    {
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.name == "Attack Skeleton")
            {
                playerHealth -= 5;
                if (PlayerHealthBar.value >= .1f) //R
                {
                    PlayerHealthBar.value -= .1f; //R
                }
            }
            else if (other.name == "Attack Goblin")
            {
                playerHealth -= 10;
                if (PlayerHealthBar.value >= .2f) //R
                {
                    PlayerHealthBar.value -= .2f; //R
                }
            }
            print("Enemy just touch by..." + playerHealth);
        }           
    }
}
