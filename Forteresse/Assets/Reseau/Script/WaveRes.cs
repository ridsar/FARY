using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;


public class WaveRes : MonoBehaviour {

    public bool check;
    public int enemyNumber;
    public int compte = 0;

    public Text beginWave;
    public Text endWave;
    bool checkText = false;
    public Text VagueText;

    uint VagueNumber;

    private float time = 0.0f;

    public AudioClip fear;
    AudioSource audio;

    // Use this for initialization
    void Start()
    {
        beginWave.enabled = false;
        endWave.enabled = false;
        VagueText.enabled = false;

        audio = GetComponent<AudioSource>();
        audio.clip = fear;
    }
    // Update is called once per frame
    void Update()
    {
        compte = 0;
        enemyNumber = 0;
        if (VagueText != null)
            VagueText.text = "Vague :  " + VagueNumber.ToString();

        foreach (Transform obj in gameObject.transform) //regarde si il reste des enemies a pop ou a tuer
        {
            compte += obj.GetComponent<SpawnRes>().myWave.Count;
            enemyNumber += obj.GetComponent<SpawnRes>().myEnemy.Count;
        }

        //Le nombre d'enemie restant a invoquer doit etre nul ainsi que le nombre d'enemie en vie. On doit appuyer sur 'F'
        if (Input.GetKey(KeyCode.F) && compte == 0 && enemyNumber == 0)
        {
            ++VagueNumber;
            audio.Play();
            VagueText.enabled = true;
            if (enemyNumber > 0)
            {
                checkText = true;
            }
            beginWave.enabled = true;
            //check = true; //sert dans le script 'Spawn'

            print("new wave"); //indicatif just pour test
            foreach (Transform obj in gameObject.transform) //va du gameobject 'A' au 'E' dans le gameobject 'Spawn'
            {
                obj.GetComponent<SpawnRes>().check = false; //met le 'check' du script Spawn sur 'false'
            }
        }
        if (beginWave != null && beginWave.enabled == true)
        {
            time += 1.0f * Time.deltaTime;
            if (time > 2.0f)
            {
                beginWave.enabled = false;
                time = 0.0f;
            }
        }
        if (checkText && enemyNumber == 0)
        {
            checkText = false;
            endWave.enabled = true;
            time += 1.0f * Time.deltaTime;
            if (time > 2.0f)
            {
                endWave.enabled = false;
                time = 0.0f;
            }
        }
    }
}
