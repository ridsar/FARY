using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class menuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Button startText;
    public Button multiplayerText;
    public Button settingsText;
    public Button exitText;
    public Camera CameraComp;
	// Use this for initialization
	void Start ()
    {
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        multiplayerText = multiplayerText.GetComponent<Button>();
        settingsText = settingsText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
	}
	
    public void ExitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        multiplayerText.enabled = false;
        settingsText.enabled = false;
        exitText.enabled = false;
    }

    public void  NoPresse()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        multiplayerText.enabled = true;
        settingsText.enabled = true;
        exitText.enabled = true;
    }

    public void SettingsPress()
    {
        
        CameraComp.transform.position = new Vector3((float)1.17, (float)6.01, (float)-11.19);
        quitMenu.enabled = false;
        startText.enabled = false;
        multiplayerText.enabled = false;
        settingsText.enabled = false;
        exitText.enabled = false;
    }

    public void StartLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void StartMulti()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitGame ()
    {
        Application.Quit();
    }
	// Update is called once per frame
	void Update () {
	
	}
}
