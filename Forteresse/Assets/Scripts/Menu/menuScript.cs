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
    public Image img1;
    public Image img2;
    public Image img3;
    public Image img4;
    public Camera CameraComp;
    public Camera CamMap2;
    public Button ArrowR;
    public Button ArrowL;
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
    public bool mappick1 = true;
    public bool mappick2 = false;

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
        img1.enabled = false;
        img2.enabled = false;
        img3.enabled = false;
        img4.enabled = false;
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
        img1.enabled = false;
        img2.enabled = false;
        img3.enabled = false;
        img4.enabled = false;

    }

    public void StartLevel()
    {
        if (mappick1)
        {
            SceneManager.LoadScene(1);
        }
        if (mappick2)
        {
            SceneManager.LoadScene(4);
        }
            
    }

    public void StartMulti()
    {
        SceneManager.LoadScene(2);
    }
    public void rightpick()
    {
        CamMap2.enabled = true;
        CameraComp.enabled = false;
        mappick2 = true;
        mappick1 = false;
    }
    public void leftpick()
    {
        CameraComp.enabled = true;
        CamMap2.enabled = false;
        mappick1 = true;
        mappick2 = false;   
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
        CamMap2.enabled = false;
        CameraComp.enabled = true;
        CameraComp.transform.position = new Vector3((float)-31, (float)-5, (float)296);
        img1.enabled = true;
        img2.enabled = true;
        img3.enabled = true;
        img4.enabled = true;
    }

    public void ExitGame ()
    {
        Application.Quit();
    }
	// Update is called once per frame
	void Update () {
	
	}
}
