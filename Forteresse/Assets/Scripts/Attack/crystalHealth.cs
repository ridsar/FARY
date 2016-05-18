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
    public Text WelcomeText; //R


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
        if (Input.GetKey(KeyCode.B))
        {
            WelcomeText.enabled = false;
        }
        if (playerHealth <= 0)
        {
            CristalHealth.value = 0; 
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DamageEnemy")
        {
            if (other.name == "Skeleton dmg")
            {
                playerHealth -= 5;
                if (CristalHealth.value >= (float)(1.0/6.0)) //R
                {
                    CristalHealth.value -= (float)(1.0/6.0); //R
                }
            }
            else if (other.name == "Goblin dmg")
            {
                playerHealth -= 10;
                if (CristalHealth.value >= (float)(1.0/3.0)) //R
                {
                    CristalHealth.value -= (float)(1.0/3.0); //R
                }
            }
            print("Enemy just touch by..." + playerHealth);
        }
    }
}
