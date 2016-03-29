using UnityEngine;
using System.Collections;

public class attackPlayerCaster : MonoBehaviour {

    private float time = 0;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Mouse0) && time <= 0 && transform.name == "Player dmg")
        {
            Vector3 pos = new Vector3(transform.position.x , transform.position.y + 2.6f, transform.position.z );
            Quaternion rot = new Quaternion(0, transform.parent.rotation.y, 0, transform.parent.rotation.w);
            var newFirebolt = Instantiate(transform, pos, rot);
            newFirebolt.name = transform.name + "(Clone)"; //Créer la boule de feu
            CancelInvoke();        

            time = 1;
        }
        if(time > 0)
            time -= 1 * Time.deltaTime;

        if (transform.name == "Player dmg(Clone)")
            transform.Translate(Vector3.forward * Time.deltaTime * 50);
    }
}
