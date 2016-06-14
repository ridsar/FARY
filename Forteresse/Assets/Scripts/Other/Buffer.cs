using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Buffer : MonoBehaviour
{
    public GameObject fireBolt;
    public bool buffed = false;


    float timeA = 0;
    float timeS = 0;
    float timeL = 0;
    float timeD = 0;

    public RawImage Heart;
    public RawImage VitesseAttack;
    public RawImage Sprint;
    public RawImage Dammage;

    public Text Chrono;

    // Use this for initialization
    void Start ()
    {
        Heart.enabled = false;
        VitesseAttack.enabled = false;
        Sprint.enabled = false;
        Dammage.enabled = false;
        Chrono.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (timeA > 0)
        {
            timeA -= 1 * Time.deltaTime;
            Chrono.text = timeA.ToString();
            Chrono.enabled = true;
            VitesseAttack.enabled = true;
        }
        else
        {
            timeA = 0;
        }
        if(timeD > 0)
        {
            timeD -= 1 * Time.deltaTime;
            Chrono.text = timeD.ToString();
            Chrono.enabled = true;
            Dammage.enabled = true;
            buffed = true;
        }
        if (timeL > 0 && GetComponent<playerHealth>().Health < GetComponent<playerHealth>().maxHealth)
        {
            timeL -= 1 * Time.deltaTime;
            Chrono.text = timeL.ToString();
            Chrono.enabled = true;
            Heart.enabled = true;
            buffed = true;
            GetComponent<playerHealth>().Health += 10f * Time.deltaTime;
            GetComponent<playerHealth>().PlayerHealthBar.value += 10f / GetComponent<playerHealth>().maxHealth * Time.deltaTime;
        }
        else
        {
            Heart.enabled = false;
            Chrono.enabled = false;
        }
        if (timeS > 0)
        {
            timeS -= 1 * Time.deltaTime;
            Chrono.text = timeS.ToString();
            Chrono.enabled = true;
            Sprint.enabled = true;
            buffed = true;
        }


        if (timeA < 0)
        {
            VitesseAttack.enabled = false;
            Chrono.enabled = false;
            if (fireBolt.activeInHierarchy)
                fireBolt.GetComponent<attackPlayerCaster>().valueTime = 1;
            else
                GetComponent<AttackPlayer>().attackSpeed = 3f;
            timeA = 0;
        }
        if (timeD < 0)
        {
            Dammage.enabled = false;
            Chrono.enabled = false;
            buffed = false;
            timeD = 0;
        }
        if (timeS < 0)
        {
            Sprint.enabled = false;
            Chrono.enabled = false;
            GetComponent<Déplacement>().Speed -= 10;
            timeS = 0;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Buff")
        {
            switch (other.name)
            {
                case "AttackSpeed(Clone)":
                    timeA = 60f;
                    if (fireBolt.activeInHierarchy)
                        fireBolt.GetComponent<attackPlayerCaster>().valueTime = 0.5f;
                    else
                        GetComponent<AttackPlayer>().attackSpeed = 1.5f;
                    break;
                case "Speed(Clone)":
                    timeS = 60f;
                    GetComponent<Déplacement>().Speed += 10;
                    break;
                case "Life(Clone)":
                    timeL = 60f;
                    break;
                case "Damage(Clone)":
                    timeD = 60f;
                    break;
            }
            Destroy(other.gameObject);
        }       
    }
}
