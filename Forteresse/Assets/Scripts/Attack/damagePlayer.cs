﻿using UnityEngine;
using System.Collections;

public class damagePlayer : MonoBehaviour
{
    public int playerHealth = 30;
    int damage = 10;
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
        if (other.tag == "Damage")
        {
            playerHealth -= damage;
            print("enemyDong just touch..." + playerHealth);
        }           
    }
}
