using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SelectHero : MonoBehaviour {

    public GameObject Hero1;
    public GameObject Hero2;
    public GameObject gui;

    public GameObject light_mage;
    public GameObject light_warrior;

    GameObject PauseMenu;
    GameObject overlord;
    GameObject mage;
    GameObject fire;
    public GameObject pause;
    bool paused;
    bool selectR = false;
    bool selectL = true;
    public bool isSelecting = true;
    public GameObject cam;


    void Start()
    {
        paused = true;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None; //Le curseur apparait et est unlock
        Cursor.visible = true;
        GameObject.Find("Main Camera").GetComponent<WowCamera>().enabled = false; //F
        GameObject.Find("Player").GetComponent<MouseLook>().enabled = false; //F

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Resume()
    {
        paused = false;
        GameObject.Find("Main Camera").GetComponent<WowCamera>().enabled = true; //F
        GameObject.Find("Player").GetComponent<MouseLook>().enabled = true; //F
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void HeroPickRight()
    {
        selectR = true;
        selectL = false;
        light_warrior.SetActive(true);
        light_mage.SetActive(false);


    }
    public void HeroPickLeft()
    {
        selectR = false;
        selectL = true;
        light_mage.SetActive(true);
        light_warrior.SetActive(false);
    }

    public void Ready()
    {
        isSelecting = false;
        gui.SetActive(true);
        GameObject.Find("PickHero").SetActive(false);
        if (selectR)
        {
            mage.SetActive(true);
            fire.SetActive(true);
        }
        if (selectL)
        {
            overlord.SetActive(true);
        }
        paused = !paused;
        GameObject.Find("Main Camera").GetComponent<WowCamera>().enabled = true; //F
        GameObject.Find("Player").GetComponent<MouseLook>().enabled = true; //F

        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked; //Le curseur disparait et est lock au milieu de l'ecran
        Cursor.visible = false;
    }
}
