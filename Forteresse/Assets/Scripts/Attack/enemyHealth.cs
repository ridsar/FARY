using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    public int playerHealth = 30;
    int dead = 0;

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
        if (other.tag == "Damage")
        {
            if (other.name == "Mage dmg")
            {
                playerHealth -= 5;
            }
            else if (other.name == "Canon dmg")
            {
                playerHealth -= 10;
            }
            print("Enemy just touch by..." + playerHealth);
        }
    }
}
