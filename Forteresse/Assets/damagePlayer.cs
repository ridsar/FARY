﻿using UnityEngine;
using System.Collections;

public class damagePlayer : MonoBehaviour
{
    public int playerHealth = 30;
    int damage = 10;

    void Start()
    {
        print(playerHealth);
    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision _collision)
    {
        if(_collision.gameObject.tag == "Damage")
        {
            playerHealth -= damage;
            print("enemyDong just touch..." + playerHealth);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {

        }
            
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            playerHealth -= damage;
            print("enemyDong just touch..." + playerHealth);
        }
    }
}
