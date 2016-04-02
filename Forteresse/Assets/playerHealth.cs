﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class playerHealth : MonoBehaviour
{

    public int Health = 100;
    int dead = 0;
    public Slider PlayerHealthBar; //R

    public int getDead()
    {
        return dead;
    }

    void Start()
    {
        print(Health);
    }

    void Update()
    {
        if (Health <= 0)
        {                 
            Destroy(gameObject);
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
                    break;
                case "Goblin dmg":
                    Health -= 10;
                    break;
                case "Skeleton dmg":
                    Health -= 20;
                    break;
            }
            print(Health);
        }
    }
    void OnTriggerStay(Collider other)
    {
        
    }
}
