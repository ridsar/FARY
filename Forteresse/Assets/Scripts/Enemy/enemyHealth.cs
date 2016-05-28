using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public float buff = 1;
    public float playerHealth;
    public Slider PlayerHealthBar; //R
    public bool isDying = false;

    public Animator anim;
    public bool animatored;
    public AnimationClip die;

    public GameObject perso;

    int dead = 0;
    float speed;
    float buffedSpeed;

    float time = 1;
    float timeDoT;
    float timeStun;
    float timeStunPerEnemy;
    float timeFrozen;

    bool canBeStuned = true;
    bool underShield = false;

    GameObject tower;
    Color fireColor;
    Color frozenColor;

    public int getDead()
    {
        return dead;
    }

    void Start()
    {
        playerHealth += playerHealth * (GameObject.Find("Spawn").transform.GetChild(0).GetComponent<Spawn>().waveNb - 1) * 0.5f;
        switch (transform.name[1])
        {
            case 'S': //Skeleton
                timeStunPerEnemy = 2f;
                fireColor = new Color(1.0f, 0.2f, 0.2f, 1.0f);
                frozenColor = new Color(0.2f, 0.2f, 1.0f, 1.0f);
                break;
            case 'G': //Goblin
                timeStunPerEnemy = 3f;
                fireColor = new Color(1.0f, 0.7f, 0.7f, 1.0f);
                frozenColor = new Color(0.7f, 0.7f, 1.0f, 1.0f);
                break;
            case 'R': //Ranger
                timeStunPerEnemy = 3f;
                fireColor = new Color(1.0f, 0.7f, 0.7f, 1.0f);
                frozenColor = new Color(0.7f, 0.7f, 1.0f, 1.0f);
                break;
            case 'T': // Troll
                timeStunPerEnemy = 0f;
                fireColor = new Color(1.0f, 0.5f, 0.5f, 1.0f);
                frozenColor = new Color(0.5f, 0.5f, 1.0f, 1.0f);
                break;
            case 'H': //Hell Keeper
                timeStunPerEnemy = 1f;
                fireColor = new Color(1.0f, 0.5f, 0.5f, 1.0f);
                frozenColor = new Color(0.5f, 0.5f, 1.0f, 1.0f);
                break;
            case 'O': //Overseer
                timeStunPerEnemy = 5f;
                fireColor = new Color(1.0f, 0.5f, 0.5f, 1.0f);
                frozenColor = new Color(0.5f, 0.5f, 1.0f, 1.0f);
                break;
            case 'N': //Necromancer
                timeStunPerEnemy = 3f;
                fireColor = new Color(1.0f, 0.5f, 0.5f, 1.0f);
                frozenColor = new Color(0.5f, 0.5f, 1.0f, 1.0f);
                break;

        }
        setSpeed();
        print(playerHealth);
    }

    void Update()
    {
        //Dot de froid provenant de la Frozen Tower
        if(timeFrozen > 0)
        {
            timeFrozen -= 1 * Time.deltaTime;
        }
        else if(timeDoT < 0 && timeFrozen < 0)
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
        else if (timeDoT < 0 && timeFrozen < 0)
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
            if(transform.GetChild(0).name != "Shield" && transform.GetChild(0).name != "model")
                transform.FindChild("targetRange").GetComponent<targetAttack>().enabled = true;
        }

        //
        if (playerHealth <= 0 && !isDying)
        {
            if (gameObject.tag == "Enemy")
            {
                
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
            isDying = true;
            GetComponent<FollowPath>().enabled = false;
            transform.GetChild(2).GetComponent<targetAttack>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
            StartCoroutine(kill());
        }
    }

    void LateUpdate()
    {
        StartCoroutine(moveSpeedBuff());
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Shield")
        {
            underShield = true;
        }

        //Gestion des degats
        if (other.tag == "Damage")
        {
            switch (other.name)
            {
                case "Canon dmg":
                    playerHealth -= 20f;
                    break;
                case "Mage dmg":
                    playerHealth -= 10f;
                    break;
                case "Player dmg":
                    if (other.GetComponentInParent<Buffer>().buffed)
                        buff = 2f;              
                    playerHealth -= (20f * buff);
                    buff = 1f;
                    break;
                case "Player dmg(Build)":
                    if (other.GetComponentInParent<attackPlayerCaster>().player.GetComponent<Buffer>().buffed)                    
                        buff = 2f;
                    playerHealth -= (20f * buff);
                    buff = 1f;
                    break;
                case "Frozen dmg":
                    playerHealth -= 3f;
                    timeFrozen = 10f;
                    GetComponent<FollowPath>().buff = 0.5f;
                    transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.color = frozenColor;
                    break;
            }
            print(playerHealth);         
        }    

        //Declanche le stun du Stun Trap
        if(other.name == "Stun Trap(Build)" && canBeStuned)
        {
            canBeStuned = false;
            timeStun = timeStunPerEnemy;
        }
    }
    void OnTriggerStay(Collider other)
    {
        //Detecte si l'ennemi est sous un bouclier ou pas
        if (other.tag == "Shield")
            underShield = underShield || true;
        else
            underShield = underShield || false;

        //modifie la vitesse de l'ennemi si il est sous le bouclier
        if (underShield)        
            GetComponent<FollowPath>().speed = buffedSpeed;
        else
            GetComponent<FollowPath>().speed = speed;
        

        //degat du Lava Floor
        if (time > 0)
            time -= 1 * Time.deltaTime;

        if(other.name == "Lava Floor(Build)" && time <= 0)
        {
            time = 1;
            playerHealth -= 1;
            print(playerHealth);
        }

        //degat de la Fire Tower
        if(other.name == "Fire dmg")
        {
            timeDoT = 10f;
            transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material.color = fireColor;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Shield")
            underShield = false;
    }


    void setSpeed()
    {
        switch (transform.name[1])
        {
            case 'S':
                speed = 10f;
                buffedSpeed = speed + speed * 0.5f;
                break;
            case 'G':
                speed = 15f;
                buffedSpeed = speed + speed * 0.5f;
                break;
            case 'R':
                speed = 10f;
                buffedSpeed = speed + speed * 0.5f;
                break;
            case 'T':
                speed = 7f;
                buffedSpeed = speed + speed * 0.5f;
                break;
            case 'H':
                speed = 7f;
                buffedSpeed = speed + speed * 0.5f;
                break;
            case 'O':
                speed = 10f;
                buffedSpeed = speed + speed * 0.5f;
                break;
            case 'N':
                speed = 8f;
                buffedSpeed = speed + speed * 0.5f;
                break;
        }
    }

    IEnumerator kill()
    {
        //aniamtion de mort !
        if (animatored)
        {
            anim.SetBool("dead", true);
        }
        else
        {
            perso.GetComponent<Animation>().Play(die.name);
        }
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        if (GameObject.Find("" + name[0]).GetComponent<Spawn>().myEnemy != null)
            GameObject.Find("" + name[0]).GetComponent<Spawn>().myEnemy.RemoveAt(0);
    }

    IEnumerator moveSpeedBuff()
    {
        if (underShield)
        {
            GetComponent<FollowPath>().speed = buffedSpeed;
        }
        else
        {
            GetComponent<FollowPath>().speed = speed;
        }
        yield return new WaitForSeconds(1f);
    }
}
