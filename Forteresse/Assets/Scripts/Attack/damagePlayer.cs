using UnityEngine;
using System.Collections;

public class damagePlayer : MonoBehaviour
{
    public int playerHealth = 100;
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
        if(playerHealth <= 0)
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
            }
            else if (other.name == "Attack Goblin")
            {
                playerHealth -= 10;
            }
            print("Enemy just touch by..." + playerHealth);
        }           
    }
}
