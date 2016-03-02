using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseScript : MonoBehaviour {

    GameObject PauseMenu;
    bool paused;

	void Start () {
        paused = false;
        PauseMenu = GameObject.Find("PauseMenu");
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }
        if (paused)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else if (!paused)
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
	
	}

    public void Resume()
    {
        paused = false;
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
