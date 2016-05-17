using UnityEngine;
using System.Collections;

public class attackPlayerCaster : MonoBehaviour {

    public GameObject player;

    private float time = 0;

    public float valueTime = 1;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Mouse0) && time <= 0 && transform.name == "Player dmg" && GameObject.Find("Player").GetComponent<Build>().canBuild == false)
        {
            var temp = player.transform;

            Vector3 pos = new Vector3(temp.position.x, 7f, temp.position.z);
            Quaternion rot = new Quaternion(0, temp.rotation.y, 0, temp.rotation.w);

            GameObject newFirebolt = Instantiate(gameObject, pos, rot) as GameObject;

            newFirebolt.name = transform.name + "(Clone)"; //Créer la boule de feu
            CancelInvoke();
            GameObject.Find("Player dmg(Clone)").GetComponent<selfDestruct>().enabled = true;
            GameObject.Find("Player dmg(Clone)").name = "Player dmg(Build)";
            time = valueTime;
        }
        if(time > 0)
            time -= 1 * Time.deltaTime;

        if (transform.name == "Player dmg(Build)")
            transform.Translate(Vector3.forward * Time.deltaTime * 50);
    }

    void OnTriggerEnter(Collider other)
    {

        if (transform.name == "Player dmg(Build)")
        {
            if (other.tag == "Enemy")
            {
                Destroy(gameObject);
            }
        }

    }
}
