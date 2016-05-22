using UnityEngine;
using System.Collections;

public class AnimationsMage : MonoBehaviour {

    public Animator anim;
    public Animation animations;
    public float inputH;
    public float inputV;
    public bool jump;
    public bool run;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
        if (Input.GetMouseButton(0))
        {
            anim.SetBool("attack", true);
            animations.Play();
        }
        else
        {
            anim.SetBool("attack", false);
        }
    }
}
