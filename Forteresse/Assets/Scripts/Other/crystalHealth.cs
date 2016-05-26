using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class crystalHealth : MonoBehaviour
{
    public int crysHealth = 30;
    int dead = 0;
    public Slider CristalHealth; //R
    public Text WelcomeText;//R
    public Text WelcomeTex;//R
    public Text WelcomeTe;
    uint nb = 0;
    int maxHealth;
    public GameObject gameobject;
    public GameObject GameOver;
    float count = 0.0f;

    public int getDead()
    {
        return dead;
    }

    void Start()
    {
        maxHealth = crysHealth;
        WelcomeTex.enabled = false;
        WelcomeTe.enabled = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.B))
        {
            nb += 1;
            selectText(nb);
        }

        if (WelcomeTe != null && WelcomeTe.enabled == true)
        {
            count += 1.0f * Time.deltaTime;
            if (count > 8.0f)
            {
                WelcomeTe.enabled = false;
                count = 0.0f;
            }
        }

        if (crysHealth <= 0)
        {
            CristalHealth.value = 0f;
            GameOver.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DamageEnemy")
        {
            switch (other.name)
            {
                case "Skeleton dmg":
                    crysHealth -= 5;
                    if (CristalHealth.value >= 5f / crysHealth) //R
                    {
                        CristalHealth.value -= 5f / crysHealth; //R
                    }
                    else
                    {
                        gameobject.SetActive(false);
                    }
                    break;
                case "Goblin dmg":
                    crysHealth -= 10;
                    if (CristalHealth.value >= 10f / crysHealth) //R
                    {
                        CristalHealth.value -= 10f / crysHealth; //R
                    }
                    else
                    {
                        gameobject.SetActive(false);
                    }
                    break;
                case "Troll dmg":
                    crysHealth -= 50;
                    if (CristalHealth.value >= 50f / crysHealth) //R
                    {
                        CristalHealth.value -= 50f / crysHealth; //R
                    }
                    else
                    {
                        gameobject.SetActive(false);
                    }
                    break;
                case "Arrow(Build)":
                    crysHealth -= 10;
                    Destroy(other);
                    if (CristalHealth.value >= 10f / crysHealth) //R
                    {
                        CristalHealth.value -= 10f / crysHealth; //R
                    }
                    else
                    {
                        gameobject.SetActive(false);
                    }
                    break;
                case "Hell Keeper dmg":
                    crysHealth -= 30;
                    if (CristalHealth.value >= 30f / maxHealth)
                    {
                        CristalHealth.value -= 30f / maxHealth;
                    }
                    break;
                case "fireBreath dmg":
                    crysHealth -= 10;
                    if (CristalHealth.value >= 10f / maxHealth)
                    {
                        CristalHealth.value -= 10f / maxHealth;
                    }
                    break;
            }           
        }
    }
    public void selectText(uint nb)
    {
        switch(nb)
        {
            case 2:
                {
                    WelcomeText.enabled = false;
                    WelcomeTex.enabled = true;
                    break;
                }
            case 4:
                {
                    WelcomeTex.enabled = false;
                    WelcomeTe.enabled = true;
                    break;
                }
           // default:
             //   WelcomeTe.enabled = false;
               // break;
        }
    }
}