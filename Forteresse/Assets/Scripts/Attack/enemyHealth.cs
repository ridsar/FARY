using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
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
            int nb = Random.Range(1, 10);
            for (int i = 0; i < nb / 2; ++i)
            {
                Vector3 pos = new Vector3(transform.position.x + Random.Range(-10, 10), transform.position.y + 2, transform.position.z + Random.Range(-10, 10));
                Instantiate(GameObject.Find("Ignot"), pos, GameObject.Find("Ignot").transform.rotation);
            }
            for (int i = 0; i < nb % 2; ++i)
            {
                Vector3 pos = new Vector3(transform.position.x + Random.Range(-10, 10), transform.position.y + 2, transform.position.z + Random.Range(-10, 10));
                Instantiate(GameObject.Find("Coin"), pos, GameObject.Find("Coin").transform.rotation);
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
                    playerHealth -= 20;
                    break;
                case "Player dmg(Build)":
                    playerHealth -= 20;
                    break;
            }
            print(playerHealth);         
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
