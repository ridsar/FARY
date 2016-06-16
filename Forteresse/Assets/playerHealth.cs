﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class playerHealth : MonoBehaviour
{

    public float Health;

    public GameObject cam;
    public GameObject deathCam;
    public GameObject respawn;
    public Canvas youredead;

    public float maxHealth;
    public Slider PlayerHealthBar; //R


    void Start()
    {
        print(Health);
        maxHealth = Health;
    }

    void Update()
    {
        if (Health <= 0)
        {
            youredead.enabled = true;
            PlayerHealthBar.value = 0f; //R

            GetComponent<pickUpMoney>().money -= 50;
            if (GetComponent<pickUpMoney>().money < 0)
                GetComponent<pickUpMoney>().money = 0;

            transform.position = respawn.transform.position; //new Vector3(443, 0, 436);

            cam.SetActive(false);
            deathCam.SetActive(true);
            gameObject.SetActive(false);

            Invoke("rePop", 5);
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
                case "Hell Keeper dmg":
                    Health -= 30;
                    if (PlayerHealthBar.value >= 30f / maxHealth)
                    {
                        PlayerHealthBar.value -= 30f / maxHealth;
                    }
                    break;
                case "fireBreath dmg":
                    Health -= 10f;
                    if (PlayerHealthBar.value >= 10f / maxHealth)
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
    void rePop()
    {
        youredead.enabled = false;
        gameObject.SetActive(true);
        cam.SetActive(true);
        deathCam.SetActive(false);
    }
}
