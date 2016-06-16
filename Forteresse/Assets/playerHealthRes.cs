using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;


public class playerHealthRes : NetworkBehaviour
{
    public float Health;
    public Slider PlayerHealthBar; //R
    public GameObject cam;
    public GameObject deathCam;
    //public Canvas youredead;

    public float maxHealth;

    void Start()
    {
        PlayerHealthBar = GameObject.Find("SliderPerso").GetComponent<Slider>();
        print(Health);
        maxHealth = Health;
    }

    void Update()
    {
        if (Health <= 0)
        {
            //youredead.enabled = true;
            PlayerHealthBar.value = 0f; //R

            GetComponent<pickUpMoney>().money -= 50;
            if (GetComponent<pickUpMoney>().money < 0)
                GetComponent<pickUpMoney>().money = 0;

            transform.position = GameObject.Find("Respawn").transform.position;

            cam.SetActive(false);
            deathCam.SetActive(true);
            deathCam.transform.rotation = new Quaternion(0.1f, -0.9f, 0.2f, 0.4f);
            deathCam.transform.position = new Vector3(462, 79, 459);
            gameObject.SetActive(false);

            Invoke("rePop", 5);
            Health = maxHealth;
            PlayerHealthBar.value = 1f; //R
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
                    if (PlayerHealthBar.value > 20f / maxHealth)   //R
                    {
                        PlayerHealthBar.value -= 20f / maxHealth; //R
                    }
                    break;
                case "Goblin dmg":
                    Health -= 10;
                    if (PlayerHealthBar.value >= 10f / maxHealth)   //R
                    {
                        PlayerHealthBar.value -= 10f / maxHealth; //R
                    }
                    break;
                case "Skeleton dmg":
                    Health -= 20;
                    if (PlayerHealthBar.value >= 20f / maxHealth)   //R
                    {
                        PlayerHealthBar.value -= 20f / maxHealth; //R
                    }
                    break;
                case "Arrow(Clone)":
                    Health -= 10;
                    Destroy(other);
                    if (PlayerHealthBar.value >= 10f / maxHealth)
                    {
                        PlayerHealthBar.value -= 10f / maxHealth;
                    }
                    break;
                case "Hell Keeper dmg":
                    Health -= 30;
                    if (PlayerHealthBar.value >= 30f / maxHealth)
                    {
                        PlayerHealthBar.value -= 30f / maxHealth;
                    }
                    break;
                case "fireBreath dmg":
                    Health -= 10f;
                    if (PlayerHealthBar.value >= 10f / maxHealth)
                    {
                        PlayerHealthBar.value -= 10f / maxHealth;
                    }
                    break;
            }
            print(Health);
        }
    }
    void OnTriggerStay(Collider other)
    {

    }
    void rePop()
    {
        //youredead.enabled = false;
        gameObject.SetActive(true);
        cam.SetActive(true);
        deathCam.SetActive(false);
    }
}
