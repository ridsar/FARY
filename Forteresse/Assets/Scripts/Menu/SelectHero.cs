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
    public Button readyB;

    GameObject PauseMenu;
    public GameObject overlord;
    public GameObject mage;
    public GameObject fire;
    public GameObject pause;
    bool paused;
    bool selectR = false;
    bool selectL = false;
    public bool isSelecting = true;
    public GameObject cam;

    public GameObject Network;


    void Start()
    {
        paused = true;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None; //Le curseur apparait et est unlock
        Cursor.visible = true;
        GameObject.Find("Main Camera").GetComponent<WowCamera>().enabled = false; //F
        readyB.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MainMenu()
    {
        Network.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void HeroPickRight()
    {
        readyB.enabled = true;
        selectR = true;
        selectL = false;
        light_warrior.SetActive(true);
        light_mage.SetActive(false);


    }
    public void HeroPickLeft()
    {
        readyB.enabled = true;
        selectR = false;
        selectL = true;
        light_mage.SetActive(true);
        light_warrior.SetActive(false);
    }

    public void Ready()
    {
        if (selectL || selectR)
        {
            isSelecting = false;
            gui.SetActive(true);
            cam.GetComponent<WowCamera>().enabled = true;

            if (selectL)
            {
                mage.SetActive(true);
                fire.SetActive(true);
                cam.GetComponent<WowCamera>().target = mage.transform;
            }
            if (selectR)
            {
                overlord.SetActive(true);
                cam.GetComponent<WowCamera>().target = overlord.transform;
            }
            paused = !paused; 
            GameObject.Find("Player").GetComponent<MouseLook>().enabled = true; //F
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked; //Le curseur disparait et est lock au milieu de l'ecran
            Cursor.visible = false;
            GameObject.Find("selectChara").SetActive(false);
            GameObject.Find("PickHero").SetActive(false);
        }     
    }
}
