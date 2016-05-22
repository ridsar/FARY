using UnityEngine;
using System.Collections;
using UnityEditor;

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
    // Use this for initialization
    void Start () {
		//AddAnim ();
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
        }
        else
        {
            CurAnimClip = 1;
            PlayAnim();
        }

    }
	
	 void OnGUI(){
		if (GUI.Button(new Rect(10, 210, 90, 50), "NestAnim"))
		{
			CurAnimClip ++;
			if(CurAnimClip > clips.Length -1)
				CurAnimClip = 0;
			PlayAnim ();
		}
		if (GUI.Button(new Rect(10, 260, 90, 50), "On One Anim"))
		{
			CurAnimClip --;
			if(CurAnimClip < 0)
				CurAnimClip = clips.Length -1;
			PlayAnim ();
		}
		if (GUI.Button(new Rect(10, 310, 90, 50), "RepeatPlay"))
		{
			PlayAnim ();
		}
		if(clips [CurAnimClip] != null)
			GUI.Label(new Rect(10, 10, 100, 20), clips [CurAnimClip].name);

//		if (GUI.Button(new Rect(10, 110, 150, 30), "NextCommodity"))
//			ChooseChar ();
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
