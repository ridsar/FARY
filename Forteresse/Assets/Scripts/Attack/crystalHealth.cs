using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class crystalHealth : MonoBehaviour {
    /*Les lignes suivies de //R sont les codes
    de Riday. Tu peux les enlever si jamais je 
    fais de la merde.*/ 
    public int playerHealth = 30;
    int dead = 0;
    public Slider CristalHealth; //R

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
        if (other.tag == "DamageEnemy")
        {
            if (other.name == "Attack Skeleton")
            {
                playerHealth -= 5;
                if (CristalHealth.value >= .1f) //R
                {
                    CristalHealth.value -= .1f; //R
                }
            }
            else if (other.name == "Attack Goblin")
            {
                playerHealth -= 10;
                if (CristalHealth.value >= .2f) //R
                {
                    CristalHealth.value -= .2f; //R
                }
            }
            print("Enemy just touch by..." + playerHealth);
        }
    }
}
