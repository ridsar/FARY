using UnityEngine;
using System.Collections;


public class ShowAnimation : MonoBehaviour {

    public GameObject[] AinObjs;
    private int CurAinObjCount = 0;
    //public GameObject AinObj;
    private Animation ain;
    public AnimationClip[] clips = new AnimationClip[5];
    public int CurAnimClip = 1;
    public string CurAnimName;
    public float inputH;
    public float inputV;


    public AudioClip pas;
    public AudioClip coups;
    AudioSource audio;
    // Use this for initialization
    void Start () {
        //AddAnim ();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        if (Input.GetMouseButton(0))
        {
            CurAnimClip = 2;
            PlayAnim();
        }
        else if (Input.GetMouseButton(0))
        {
            CurAnimClip = 2;
            PlayAnim();


            audio.clip = coups;
            audio.loop = false;
            audio.Play();
        }
        else if (Input.GetMouseButton(1))
        {
            CurAnimClip = 3;
            PlayAnim();
        }
        else if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.S))
        {
            CurAnimClip = 0;
            PlayAnim();

            audio.clip = pas;
            audio.loop = true;
            audio.Play();
        }
        else
        {
            CurAnimClip = 1;
            PlayAnim();
        }

    }
	
	 

	public GameObject[] Chrs;
	public int i =0;
	private int curi =0;
	void ChooseChar ()
	{
		CurAinObjCount = i;
		AinObjs [CurAinObjCount].SetActive(false);
		i +=1;
		if(i == AinObjs.Length)
		{
			i =0;
		}
		AinObjs [i].SetActive(true);
		//AddAnim ();
	}

	
	/*void AddAnim () 
	{
		ain = AinObjs [i].GetComponent<Animation>();
		clips = AnimationUtility.GetAnimationClips(ain);
	}*/
	void PlayAnim ()
	{
		AinObjs [i].GetComponent<Animation>().Play (clips [CurAnimClip].name);
		CurAnimName = clips [CurAnimClip].name;
	}
}
