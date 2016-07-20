using UnityEngine;
using System.Collections;

public class networkCursor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Cursor.lockState = CursorLockMode.None; //Le curseur apparait et est unlock
        Cursor.visible = true;
    }
}
