using UnityEngine;
using System.Collections;

public class NecroBuff : MonoBehaviour
{
    float Health;
    bool isBuffed = false;

    // Use this for initialization
    void Start()
    {
        Health = GetComponent<enemyHealth>().playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBuffed)
        {
            transform.GetChild(3).gameObject.SetActive(true);
            Health += 0.05f * Time.deltaTime;
        }
        else
        {
            transform.GetChild(3).gameObject.SetActive(false);
        }
    }
    void OnTriggerStay(Collider other)  
    {                                  
        if (other.name == "NecroHalo")
        {
            isBuffed = isBuffed || true; 
        }
        else
        {
            isBuffed = isBuffed || false; 
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "NecroHalo")
        {
            isBuffed = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "NecroHalo")
        {
            isBuffed = true;
        }
    }
}