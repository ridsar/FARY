using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class crystalHealth : MonoBehaviour {
    /*Les lignes suivies de //R sont les codes
    de Riday. Tu peux les enlever si jamais je 
    fais de la merde.*/ 
    public int crysHealth = 30;
    int dead = 0;
    public Slider CristalHealth; //R
    public Text WelcomeText; //R
    int maxHealth;


    public int getDead()
    {
        return dead;
    }

    void Start()
    {
        maxHealth = crysHealth;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.B))
        {
            WelcomeText.enabled = false;
        }
        if (crysHealth <= 0)
        {
            CristalHealth.value = 0f; 
            Destroy(gameObject);
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DamageEnemy")
        {
            //Degat des squelettes 
            if (other.name == "Skeleton dmg")
            {
                crysHealth -= 5;
                if (CristalHealth.value >= 5f / crysHealth) //R
                {
                    CristalHealth.value -= 5f / crysHealth; //R
                }
                else
                {
                    CristalHealth.value = 0;
                }
            }
            //Degat des goblins
            else if (other.name == "Goblin dmg")
            {
                crysHealth -= 10;
                if (CristalHealth.value >= 10f / crysHealth) //R
                {
                    CristalHealth.value -= 10f / crysHealth; //R
                }
                else
                {
                    CristalHealth.value = 0;
                }
            }
            //Degat des trolls
            else if (other.name == "Troll dmg")
            {
                crysHealth -= 50;
                if (CristalHealth.value >= 50f / crysHealth) //R
                {
                    CristalHealth.value -= 50f / crysHealth; //R
                }
                else
                {
                    CristalHealth.value = 0;
                }
            }
        }
    }
}
