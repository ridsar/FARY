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
    public Text Play;
    public Button Play2;
    public Text Play2Text;
    public Text Multi;
    public Text Settings;
    public Text Exit;
    public Canvas SettingsMenu;
    public Canvas PlayMenu;
    public Button Goback;
    public Button Goback2;
    public float distance;
    public float lift;
    public bool cameraTurnIsFixed = false;
    public bool overlordpick = false;
    public bool magepick = false;

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

    public void NoPresse()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        multiplayerText.enabled = true;
        settingsText.enabled = true;
        exitText.enabled = true;
    }

    public void SettingsPress()
    {
        
        startText.enabled = false;
        multiplayerText.enabled = false;
        settingsText.enabled = false;
        exitText.enabled = false;
        Play.enabled = false;
        Multi.enabled = false;
        Settings.enabled = false;
        Exit.enabled = false;
        SettingsMenu.enabled = true;
        CameraComp.transform.position = new Vector3((float)-30, (float)-7, (float)207) + new Vector3(0, lift, distance);
    }

    public void play ()
    {
        CameraComp.transform.position = new Vector3((float)-30, (float)-7, (float)207) + new Vector3(0, lift, distance);
        startText.enabled = false;
        multiplayerText.enabled = false;
        settingsText.enabled = false;
        exitText.enabled = false;
        Play.enabled = false;
        Multi.enabled = false;
        Settings.enabled = false;
        Exit.enabled = false;
        PlayMenu.enabled = true;
    }

    public void StartLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void StartMulti()
    {
        SceneManager.LoadScene(2);
    }
    public void rightpick()
    {
        overlordpick = true;
        magepick = false;
        Play2.enabled = true;
    }
    public void leftpick()
    {
        overlordpick = false;
        magepick = true;
        Play2.enabled = true;
    }
    public void GoBack ()
    {
        SettingsMenu.enabled = false;
        PlayMenu.enabled = false;
        startText.enabled = true;
        multiplayerText.enabled = true;
        settingsText.enabled = true;
        exitText.enabled = true;
        Play.enabled = true;
        Multi.enabled = true;
        Settings.enabled = true;
        Exit.enabled = true;
        CameraComp.transform.position = new Vector3((float)-31, (float)-5, (float)296);
    }

    public void ExitGame ()
    {
        Application.Quit();
    }
	// Update is called once per frame
	void Update () {
	
	}
}
