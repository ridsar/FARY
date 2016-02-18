using UnityEngine;
using System.Collections;

public class Déplacement : MonoBehaviour
{

    // Use this for initialization
    public Rigidbody rb;
    public float Speed;
    public float rotateSpeed;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //var GObj = GameObject.Find("Terrain");
        Vector3 rotate = new Vector3();
        Vector3 move = new Vector3();

        RaycastHit hit;
        float theDistance;

        Vector3 downSide = transform.TransformDirection(Vector3.down) * 10;

        if (Physics.Raycast(transform.position, (downSide), out hit))
            theDistance = hit.distance;
        

        if (Input.GetKey(KeyCode.Q))
            rotate.y -= rotateSpeed;
        if (Input.GetKey(KeyCode.D))
            rotate.y += rotateSpeed;
        double cosAngle = Mathf.Cos(transform.eulerAngles.y * Mathf.PI / 180);
        double sinAngle = Mathf.Sin(transform.eulerAngles.y * Mathf.PI / 180);
        if (Input.GetKey(KeyCode.Z))
        {
            move.z = move.z + (Speed * (float)cosAngle);
            move.x = move.x + (Speed * (float)sinAngle);
        }
        if (Input.GetKey(KeyCode.S))
        {
            move.z = move.z - (Speed * (float)cosAngle);
            move.x = move.x - (Speed * (float)sinAngle);
        }

        if (Input.GetKey(KeyCode.A))
            move.x -= Speed;
        if (Input.GetKey(KeyCode.E))
            move.x += Speed;
        
        theDistance = hit.distance;

        if (Input.GetKey(KeyCode.Space) && theDistance < 0.5)
            rb.AddForce(0, 80, 0);

        if (theDistance > 2)
            rb.AddForce(0, -50, 0);  
           
        transform.Rotate(rotate, 5);
        transform.position += move;       
    }
}
