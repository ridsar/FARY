using UnityEngine;
using System.Collections;

public class shieldFade : MonoBehaviour
{
    float buff = 1;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.GetComponent<enemyHealth>().playerHealth < 100)
        {
            gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Shield")
        {
        }
        if (other.tag == "Damage")
        {
            switch (other.name)
            {
                case "Canon dmg":
                    transform.parent.GetComponent<enemyHealth>().playerHealth -= 20;
                    break;
                case "Mage dmg":
                    transform.parent.GetComponent<enemyHealth>().playerHealth -= 10;
                    break;
                case "Player dmg":
                    if (other.GetComponentInParent<Buffer>().buffed)
                        buff = 2;
                    transform.parent.GetComponent<enemyHealth>().playerHealth -= (20 * buff);
                    buff = 1;
                    break;
                case "Player dmg(Build)":
                    if (other.GetComponentInParent<attackPlayerCaster>().player.GetComponent<Buffer>().buffed)
                        buff = 2;
                    transform.parent.GetComponent<enemyHealth>().playerHealth -= (20 * buff);
                    buff = 1;
                    break;
                case "Frozen dmg":
                    transform.parent.GetComponent<enemyHealth>().playerHealth -= 3;
                    GetComponent<FollowPath>().buff = 0.5f;
                    break;
            }
        }
    }
}
