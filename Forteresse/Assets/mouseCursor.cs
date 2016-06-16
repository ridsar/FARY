using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class mouseCursor : NetworkBehaviour
{
    bool visible = false;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (!isLocalPlayer)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            visible = !visible;
        }

        if (visible)
        {
            Cursor.lockState = CursorLockMode.None; //Le curseur apparait et est unlock
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked; //Le curseur apparait et est unlock
            Cursor.visible = false;
        }
	}
}
