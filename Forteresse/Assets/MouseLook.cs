using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

    public float lookSensitivity = 5f;
    public float xRotation;
    public float yRotation;
    public float currentXRotation;
    public float currentYRotation;
    public float xRotationV;
    public float yRotationV;
    public float lookSmoothDamp = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButton(0))
        {
        }
        else
        {
            yRotation += Input.GetAxis("Mouse X") * lookSensitivity;
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        }
	}
}
