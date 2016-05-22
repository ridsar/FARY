using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public float buff = 1;
    public float playerHealth = 100;
    public Slider PlayerHealthBar; //R

    int dead = 0;

    float time = 1;
    float timeDoT;
    float timeStun;
    float timeStunPerEnemy;
    float timeFrozen;

    bool canBeStuned = true;

    GameObject tower;
    Color fireColor;
    Color frozenColor;

    public int getDead()
    {
        return dead;
    }

    void Start()
    {
        switch (transform.name[1])
        {
            case 'S':
                timeStunPerEnemy = 2f;
                fireColor = new Color(1.0f, 0.2f, 0.2f, 1.0f);
                frozenColor = new Color(0.2f, 0.2f, 1.0f, 1.0f);
                break;
            case 'G':
                timeStunPerEnemy = 3f;
                fireColor = new Color(1.0f, 0.7f, 0.7f, 1.0f);
                frozenColor = new Color(0.7f, 0.7f, 1.0f, 1.0f);
                break;
            case 'R':
                timeStunPerEnemy = 3f;
                fireColor = new Color(1.0f, 0.7f, 0.7f, 1.0f);
                frozenColor = new Color(0.7f, 0.7f, 1.0f, 1.0f);
                break;
            case 'T':
                timeStunPerEnemy = 0f;
                fireColor = new Color(1.0f, 0.5f, 0.5f, 1.0f);
                frozenColor = new Color(0.5f, 0.5f, 1.0f, 1.0f);
                break;

        }
        print(playerHealth);
    }

    void Update()
    {
        //Dot de froid provenant de la Frozen Tower
        if(timeFrozen > 0)
        {
            timeFrozen -= 1 * Time.deltaTime;
        }
        else
        {
            GetComponent<FollowPath>().buff = 1;
            transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
            

        //Dot de feu provenant de la Fire Tower
        if (timeDoT > 0)
        {
            timeDoT -= 1 * Time.deltaTime;
            playerHealth -= 1f * Time.deltaTime;
        }
        else
            transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        //Stun provenant du Stun Trap
        if(timeStun > 0)
        {
            timeStun -= 1 * Time.deltaTime;
            transform.GetComponent<FollowPath>().enabled = false;
            transform.FindChild("targetRange").GetComponent<targetAttack>().enabled = false;
        }
        else if (timeStun > -5 && timeStun <= 0)
        {
            timeStun = -10f;
            transform.GetComponent<FollowPath>().enabled = true;
            transform.FindChild("targetRange").GetComponent<targetAttack>().enabled = true;
        }



        //
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
                    if (other.GetComponentInParent<Buffer>().buffed)
                        buff = 2;              
                    playerHealth -= (20 * buff);
                    buff = 1;
                    break;
                case "Player dmg(Build)":
                    if (other.GetComponentInParent<attackPlayerCaster>().player.GetComponent<Buffer>().buffed)                    
                        buff = 2;
                    playerHealth -= (20 * buff);
                    buff = 1;
                    break;
                case "Frozen dmg":
                    playerHealth -= 3;
                    timeFrozen = 10f;
                    GetComponent<FollowPath>().buff = 0.5f;
                    transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.color = frozenColor;
                    break;
            }
            print(playerHealth);         
        }    
        if(other.name == "Stun Trap(Build)" && canBeStuned)
        {
            canBeStuned = false;
            timeStun = timeStunPerEnemy;
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
            transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.color = fireColor;
        }
    }
}
