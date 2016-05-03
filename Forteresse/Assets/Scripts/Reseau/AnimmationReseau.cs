using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class AnimmationReseau : NetworkBehaviour {

    public Animator anim;
    public float inputH;
    public float inputV;
    public bool jump;
    public bool run;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            inputH = Input.GetAxis("Horizontal");
            inputV = Input.GetAxis("Vertical");

            anim.SetFloat("inputH", inputH);
            anim.SetFloat("inputV", inputV);

            if (Input.GetKey(KeyCode.Space))
            {
                anim.SetBool("jump", true);
            }
            else
            {
                anim.SetBool("jump", false);
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("run", true);
            }
            else
            {
                anim.SetBool("run", false);
            }
            if (Input.GetMouseButton(0))
            {
                anim.SetBool("attack", true);
            }
            else
            {
                anim.SetBool("attack", false);
            }
        }
    }
}
