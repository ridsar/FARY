using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public float dmgPlayer = 20;
    public float playerHealth = 100;
    public Slider PlayerHealthBar; //R

    int dead = 0;

    float time = 1;
    float timeDoT;

    bool check = true;

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
        if (timeDoT > 0)
        {
            check = true;
            timeDoT -= 1 * Time.deltaTime;
            playerHealth -= 1f * Time.deltaTime;
            print(playerHealth);
        }
        else
            transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.color = new Color(1.0f, 1f, 1f, 1.0f);

        if (playerHealth <= 0)
        {
            if (gameObject.tag == "Enemy")
            {
                if(GameObject.Find("" + name[0]).GetComponent<Spawn>().myEnemy != null)
                    GameObject.Find("" + name[0]).GetComponent<Spawn>().myEnemy.RemoveAt(0);
                if(tower != null)
                {
                    tower.GetComponent<Attack>().check = true;
                }
            }
            int nb = Random.Range(0, 10);
            if(nb == 1)
            {
                int rnd = Random.Range(0, 4);
                GameObject buff = Instantiate(GameObject.FindGameObjectsWithTag("Buff")[rnd]) as GameObject;
                buff.transform.position = transform.position;
            }
            for (int i = 0; i < (nb / 5); ++i)
            {
                Vector3 pos = new Vector3(transform.position.x + Random.Range(-10, 10), transform.position.y + 0.5f, transform.position.z + Random.Range(-10, 10));
                Instantiate(GameObject.Find("Ignot"), pos, GameObject.Find("Ignot").transform.rotation);
            }
            for (int i = 0; i < nb % 5; ++i)
            {
                Vector3 pos = new Vector3(transform.position.x + Random.Range(-10, 10), transform.position.y + 0.5f, transform.position.z + Random.Range(-10, 10));
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
                    playerHealth -= dmgPlayer;
                    break;
                case "Player dmg(Build)":
                    playerHealth -= dmgPlayer;
                    break;
            }
            print(playerHealth);         
        }             
    }
    void OnTriggerStay(Collider other)
    {
        if (time > 0)
            time -= 1 * Time.deltaTime;
        if(other.name == "Lava Floor(Build)" && time <= 0)
        {
            time = 1;
            playerHealth -= 1;
            print(playerHealth);
        }
        if(other.name == "Fire dmg")
        {
            timeDoT = 10f;
            transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.color = new Color(1.0f, 0.2f, 0.2f, 1.0f);
        }
    }
}
