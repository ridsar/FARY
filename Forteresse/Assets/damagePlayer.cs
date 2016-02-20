using UnityEngine;
using System.Collections;

public class damagePlayer : MonoBehaviour
{
    public int playerHealth = 30;
    int damage = 10;

    void Start()
    {
        
    }

    void Update()
    {

    }


    /*public damagePlayer (int health)
    {
        this.playerHealth = health;
    }



    public int getHealth()
    {
        return this.playerHealth;
    }*/



    void OnCollisionEnter(Collision _collision)
    {
        if(_collision.gameObject.tag == "Damage")
        {
            playerHealth -= damage;
            print("enemyDong just touch..." + playerHealth);
        }
    }    
}
