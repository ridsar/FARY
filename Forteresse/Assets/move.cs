using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

    public GameObject sphere;

    private Vector3 startPos;

    private Vector3 endPos;

    private float distance = 30f;

    private float lerpTime = 5;

    private float currentLerpTime = 0;

    private bool keyHit = false;

	// Use this for initialization
	void Start ()
    {
        startPos = sphere.transform.position;
        endPos = sphere.transform.position + Vector3.forward * distance;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.P))
        {
            keyHit = true;
        }
        if( keyHit == true)
        {
            currentLerpTime += Time.deltaTime;
            if(currentLerpTime >= lerpTime)
            {
                currentLerpTime = lerpTime;
            }
            float Perc = currentLerpTime / lerpTime;
            sphere.transform.position = Vector3.Lerp(startPos, endPos, Perc);
        }
    }
}
