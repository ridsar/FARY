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
            case 'H':
                timeStunPerEnemy = 1f;
                fireColor = new Color(1.0f, 0.5f, 0.5f, 1.0f);
                frozenColor = new Color(0.5f, 0.5f, 1.0f, 1.0f);
                break;
            case 'O':
                timeStunPerEnemy = 5f;
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
            if(transform.GetChild(0).name != "Shield")
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
        if (other.tag == "Damage")
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
        if(other.tag == "Shield")
        {
            underShield = underShield || true;
        }
        else
        {
            underShield = underShield || false;
        }
        if (underShield)
        {
            GetComponent<FollowPath>().speed = buffedSpeed;
        }
        else
        {
            GetComponent<FollowPath>().speed = speed;
        }


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
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Shield")
        {
            underShield = false;
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
        }
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
        yield return new WaitForSeconds(1);
    }
}
