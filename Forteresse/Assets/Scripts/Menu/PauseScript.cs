using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseScript : MonoBehaviour {

    public GameObject PauseMenu;
    public GameObject isSelect;
    public GameObject Gameover;
    public int currentscene;
    GameObject overlord;
    GameObject mage;
    GameObject fire;
    bool paused;
    bool selectR = false;
    bool selectL = true;

    void Start ()
    {
        paused = false;
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
        if (paused || Gameover.activeInHierarchy)
        {
            if(paused)
            {
                PauseMenu.SetActive(true);
            }
            if (Gameover.activeInHierarchy)
            {
                GameObject.Find("Main Camera").GetComponent<WowCamera>().enabled = false; //F
                GameObject.Find("Player").GetComponent<MouseLook>().enabled = false; //F
            }
            
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None; //Le curseur apparait et est unlock
            Cursor.visible = true;
        }
        else if (!paused && isSelect.activeInHierarchy == false)
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
        SceneManager.LoadScene(1);
    }

    public void Save ()
    {
        PlayerPrefs.SetInt("currentscenesave", 1);
    }
    public void Load()
    {
        SceneManager.LoadScene(currentscene);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
