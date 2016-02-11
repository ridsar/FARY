using UnityEngine;
using System.Collections;

public class Déplacement : MonoBehaviour
{

    // Use this for initialization
    public Rigidbody rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var GObj = GameObject.Find("Terrain");
        Vector3 rotate = new Vector3();
        Vector3 move = new Vector3();

        if (Input.GetKey(KeyCode.Q))
            rotate.y -= 10f;
        if (Input.GetKey(KeyCode.D))
            rotate.y += 10f;
        print(move.z);
        print(move.y);
        double cosAngle = Mathf.Cos(transform.eulerAngles.y * Mathf.PI / 180);
        double sinAngle = Mathf.Sin(transform.eulerAngles.y * Mathf.PI / 180);
        if (Input.GetKey(KeyCode.Z))
        {
            move.z = move.z + (0.2f * (float)cosAngle);
            move.x = move.x + (0.2f * (float)sinAngle);
        }
        if (Input.GetKey(KeyCode.S))
        {
            move.z = move.z - (0.2f * (float)cosAngle);
            move.x = move.x - (0.2f * (float)sinAngle);
        }

        if (Input.GetKey(KeyCode.A))
            move.x -= 0.2f;
        if (Input.GetKey(KeyCode.E))
            move.x += 0.2f;
        if (Input.GetKey(KeyCode.Space) && transform.position.y - GObj.transform.position.y < 0.5)
            rb.AddForce(0, 50, 0);

        if (transform.position.y - GObj.transform.position.y > 2)
            rb.AddForce(0, -20, 0);  
           
        transform.Rotate(rotate, 5);
        transform.position += move;       
    }
}
