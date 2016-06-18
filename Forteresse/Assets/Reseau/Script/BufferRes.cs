﻿using UnityEngine;
using System.Collections;
//using UnityEngine.Networking;
using UnityEngine.UI;


public class BufferRes : MonoBehaviour /*NetworkBehaviour*/
{

    public GameObject fireBolt;
    public bool buffed = false;

    float buffedSpeed;
    float normalSpeed;

    float timeA = 0;
    float timeS = 0;
    float timeL = 0;
    float timeD = 0;

    public RawImage Heart;
    public RawImage VitesseAttack;
    public RawImage Sprint;
    public RawImage Dammage;

    public Text ChronoHeart;
    public Text ChronoVitesseAtack;
    public Text ChronoDammage;
    public Text ChronoSprint;

    // Use this for initialization
    void Start()
    {
        Heart = GameObject.Find("Heart").GetComponent<RawImage>();
        VitesseAttack = GameObject.Find("VitesseAttack").GetComponent<RawImage>();
        Sprint = GameObject.Find("Sprint").GetComponent<RawImage>();
        Dammage = GameObject.Find("Dammage").GetComponent<RawImage>();

        ChronoDammage = GameObject.Find("ChronoDamage").GetComponent<Text>();
        ChronoSprint = GameObject.Find("ChronoSprint").GetComponent<Text>();
        ChronoVitesseAtack = GameObject.Find("ChronoVitesseAtack").GetComponent<Text>();
        ChronoHeart = GameObject.Find("ChronoHeart").GetComponent<Text>();

        buffedSpeed = GetComponent<Déplacement>().Speed + 10f;
        normalSpeed = GetComponent<Déplacement>().Speed;

        Heart.enabled = false;
        VitesseAttack.enabled = false;
        Sprint.enabled = false;
        Dammage.enabled = false;
        ChronoHeart.enabled = false;
        ChronoDammage.enabled = false;
        ChronoSprint.enabled = false;
        ChronoVitesseAtack.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeA > 0)
        {
            timeA -= 1 * Time.deltaTime;
            ChronoVitesseAtack.text = ((int)timeA).ToString();
            ChronoVitesseAtack.enabled = true;
            VitesseAttack.enabled = true;
        }
        else
            timeA = 0;

        if (timeD > 0)
        {
            timeD -= 1 * Time.deltaTime;
            ChronoDammage.text = ((int)timeD).ToString();
            ChronoDammage.enabled = true;
            Dammage.enabled = true;
            buffed = true;
        }
        if (timeL > 0 && GetComponent<playerHealthRes>().Health < GetComponent<playerHealth>().maxHealth)
        {
            buffed = true;
            timeL -= 1 * Time.deltaTime;
            ChronoHeart.text = ((int)timeL).ToString();
            ChronoHeart.enabled = true;
            Heart.enabled = true;
            GetComponent<playerHealthRes>().Health += 10f * Time.deltaTime;
            GetComponent<playerHealthRes>().PlayerHealthBar.value += 10f / GetComponent<playerHealth>().maxHealth * Time.deltaTime;
        }
        else
        {
            Heart.enabled = false;
            ChronoHeart.enabled = false;
        }
        if (timeS > 0)
        {
            timeS -= 1 * Time.deltaTime;
            ChronoSprint.text = ((int)timeS).ToString();
            ChronoSprint.enabled = true;
            Sprint.enabled = true;
            buffed = true;
        }



        if (timeA < 0)
        {
            VitesseAttack.enabled = false;
            ChronoVitesseAtack.enabled = false;
            if (fireBolt.activeInHierarchy)
                fireBolt.GetComponent<attackPlayerCaster>().valueTime = 1;
            else
                GetComponent<AttackPlayer>().attackSpeed = 3f;
            timeA = 0;
        }
        if (timeD < 0)
        {
            Dammage.enabled = false;
            ChronoDammage.enabled = false;
            buffed = false;
            timeD = 0;
        }
        if (timeS < 0)
        {
            Sprint.enabled = false;
            ChronoSprint.enabled = false;
            GetComponent<Déplacement>().Speed = normalSpeed;
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
