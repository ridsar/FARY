using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class damagePlayer : MonoBehaviour
{
    public int playerHealth = 100;
    int dead = 0;
    public Slider PlayerHealthBar; //R

    GameObject tower;

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
            if (gameObject.tag == "Enemy")
            {
                GameObject.Find("" + name[0]).GetComponent<Spawn>().myEnemy.RemoveAt(0);
                if(tower != null)
                {
                    tower.GetComponent<Attack>().check = true;
                }
            }
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Damage")
        {
            switch (other.name)
            {
                case "Canon dmg":
                    playerHealth -= 20;
                    break;
                case "Mage dmg":
                    playerHealth -= 10;
                    break;
                case "Player dmg":
                    playerHealth -= 40;
                    break;
            }          
        }
        if (other.tag == "Player")
        {
            if (other.name == "Attack Skeleton")
            {
                playerHealth -= 5;
                if (PlayerHealthBar.value >= .1f) //R
                {
                    PlayerHealthBar.value -= .1f; //R
                }
            }
            else if (other.name == "Attack Goblin")
            {
                playerHealth -= 10;
                if (PlayerHealthBar.value >= .2f) //R
                {
                    PlayerHealthBar.value -= .2f; //R
                }
            }
            print("Enemy just touch by..." + playerHealth);
        }           
    }
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Tower")
        {
            tower = other.gameObject;
        }
    }
}
