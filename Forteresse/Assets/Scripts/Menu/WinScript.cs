using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void MainMenu()
    {
        SceneManager.LoadScene(1);
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
