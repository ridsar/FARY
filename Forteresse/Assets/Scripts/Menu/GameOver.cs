using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour {

    public GameObject Gameover;
    public Light Lightsky;
    public float duration = 1.0F;
    public Color color0 = Color.red;
    public Color color1 = Color.blue;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Gameover.activeInHierarchy == true)
        {
            float t = Mathf.PingPong(Time.time, duration) / duration;
            Lightsky.color = Color.Lerp(color0, color1, t);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None; //Le curseur apparait et est unlock
            Cursor.visible = true;
        }
        
	}

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Save()
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
