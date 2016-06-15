using UnityEngine;
using System.Collections;

public class Animations : MonoBehaviour {

    public Animator anim;
    public float inputH;
    public float inputV;
    public bool jump;
    public bool run;
    public AudioClip pas;
    public AudioClip coups;
    public AudioClip mort;
    AudioSource audio;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        if (inputH ==0 && inputV ==0)
        {
            audio.loop = false;
        }

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
        if (Input.GetKeyDown(KeyCode.LeftShift))         
        {
            anim.SetBool("run", true);
            audio.clip = pas;
            audio.loop = true;
            audio.Play();
        }
        else
        {
            anim.SetBool("run", false);
        }
        if (Input.GetMouseButton(0))
        {
            anim.SetBool("attack", true);
            audio.clip = coups;
            audio.loop = false;
            audio.Play();
        }
        else
        {
            anim.SetBool("attack", false);
        }
        
    }
}
