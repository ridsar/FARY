﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class crystalHealth : MonoBehaviour
{
    public int crysHealth = 30;
    int dead = 0;
    public Slider CristalHealth; //R
    public Text WelcomeText;//R
    public Text WelcomeTex;//R
    int maxHealth;
    public GameObject gameobject;

    public int getDead()
    {
        return dead;
    }

    void Start()
    {
        maxHealth = crysHealth;
        WelcomeTex.enabled = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.B))
        {
            WelcomeText.enabled = false;
            WelcomeTex.enabled = true;
        }
        if (Input.GetKey(KeyCode.P))
        {
            WelcomeTex.enabled = false;
        }
        if (crysHealth <= 0)
        {
            CristalHealth.value = 0f;

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
                    gameobject.SetActive(false);
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
                    gameobject.SetActive(false);
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
                    gameobject.SetActive(false);
                }
            }
        }
    }
}
