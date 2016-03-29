﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseScript : MonoBehaviour {

    GameObject PauseMenu;
    bool paused;


	void Start ()
    {
        paused = false;
        PauseMenu = GameObject.Find("PauseMenu");
        Cursor.lockState = CursorLockMode.Confined;
        
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            if (!paused) //F
            {
                GameObject.Find("Main Camera").GetComponent<WowCamera>().enabled = true; //F
                GameObject.Find("Player").GetComponent<MouseLook>().enabled = true; //F
            }
            else
            {
                GameObject.Find("Main Camera").GetComponent<WowCamera>().enabled = false; //F
                GameObject.Find("Player").GetComponent<MouseLook>().enabled = false; //F
            }
        }
        if (paused)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None; //Le curseur apparait et est unlock
            Cursor.visible = true;
        }
        else if (!paused)
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked; //Le curseur disparait et est lock au milieu de l'ecran
            Cursor.visible = false;
        }
	}

    public void Resume()
    {
        paused = false;
        GameObject.Find("Main Camera").GetComponent<WowCamera>().enabled = true; //F
        GameObject.Find("Player").GetComponent<MouseLook>().enabled = true; //F
    }

    public void MainMenu ()
    {
        SceneManager.LoadScene(0);
    }

    public void Save ()
    {
        PlayerPrefs.SetInt("currentscenesave", 1);
    }
    public void Load()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("currentscenesave"));
    }
    public void Quit()
    {
        Application.Quit();
    }
}
