using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class FollowPath : MonoBehaviour {

	#region Attributes
	public Transform pathToFollow;
	public MovementTypes type = MovementTypes.Follow;
	/*[SerializeField][Range(0.1F, 100.0F)]*/ public float speed;
    public float buff = 1;
	
	[SerializeField][Range(0.0F, 60.0F)] public float minWaitTime;
	[SerializeField][Range(0.0F, 60.0F)] public float maxWaitTime;

	// Animations
	public string walkAnimation = null;
	public string idleAnimation = null;
	public List<string> otherAnimations = new List<string>();
	[SerializeField][Range(1, 100)] public int AnimFrequency = 50;


	private List<Transform> listPaths = new List<Transform>();
	public int index = 1;
	private bool walk = false;
	public Transform currentTarget;
	private Transform lastTarget;

    private char path;
	#endregion
	
	#region Unity methods
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start ()
    {
        switch (gameObject.name[0])
        {
            case 'A':
                path = 'A';
                pathToFollow = GameObject.Find("PathA").transform;
                break;
            case 'B':
                path = 'B';
                pathToFollow = GameObject.Find("PathB").transform;
                break;
            case 'C':
                path = 'C';
                pathToFollow = GameObject.Find("PathC").transform;
                break;
            case 'D':
                path = 'D';
                pathToFollow = GameObject.Find("PathD").transform;
                break;
            case 'E':
                path = 'E';
                pathToFollow = GameObject.Find("PathE").transform;
                break;
        }

		if(pathToFollow == null)
        {
			
		}
        else
        {
			GetPaths();

			switch(type){
			case MovementTypes.Follow:
				index = index;
				break;
			case MovementTypes.Random:
				index = 1;
				break;
			case MovementTypes.Reverse:
				index = listPaths.Count;
				break;
			}

			if(listPaths.Count > 0)
                GetNewPosition();
		}
    }

    /// <summary>
    /// Update this instance.
    /// </summary>
    void Update ()
    {
		if(walk)
            StartWalk();
    }
    #endregion

    #region Other methods
    /// <summary>
    /// Get all paths.
    /// </summary>
    void GetPaths(){
		foreach(Transform temp in pathToFollow){
			//if(temp.tag == "Path"){
				listPaths.Add(temp);
			//}
		}
		PathsOrientation();
	}

	/// <summary>
	/// Paths orientation.
	/// </summary>
	void PathsOrientation()
    {
		int nb = listPaths.Count();
		for(int i = 2; i <= nb; i++)
        {
			Transform premier = listPaths.Single(p => p.name == "Path" + path + (i-1));
			Transform deuxieme = listPaths.Single(p => p.name == "Path" + path + i);
			
			premier.LookAt(deuxieme.position);
			if(i == nb) deuxieme.LookAt(listPaths.Single(p => p.name == "Path" + path + "1").position);
		}
	}

	/// <summary>
	/// Get the new position.
	/// </summary>
	void GetNewPosition(){

		switch(type){
			case MovementTypes.Follow:
                if (index <= listPaths.Count)
                {
                    currentTarget = listPaths.Single(p => p.name == "Path" + path + index);
                    transform.LookAt(currentTarget);
                    index = /*(index < listPaths.Count) ? */index + 1;// : 1;
                }
                else
                {
                    currentTarget = null;
                    lastTarget = null;
                    walk = false;
                    PlayAnimation(idleAnimation);
                    return;
                }       
                break;
            case MovementTypes.Random:
				currentTarget = listPaths[Random.Range(0, listPaths.Count)];
				break;
			case MovementTypes.Reverse:
				currentTarget = listPaths.Single(p => p.name == "Path" + path + index);
				index = (index > 1) ? index -1 : listPaths.Count;
				break;
		}

		StartCoroutine(Wait());
	}

	/// <summary>
	/// Start walking.
	/// </summary>
	void StartWalk(){
		if(currentTarget != null){
			transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, Time.deltaTime * speed * buff);
            PlayAnimation(walkAnimation);

            if (CheckDistance() <= 0.5f)
            {
				walk = false;
				lastTarget = currentTarget;
				GetNewPosition();
			}
		}
	}

	/// <summary>
	/// Check the distance.
	/// </summary>
	/// <returns>The distance.</returns>
	float CheckDistance()
    {
		return Vector3.Distance(transform.position, currentTarget.position);
	}

	/// <summary>
	/// Wait time
	/// </summary>
	IEnumerator Wait()
    {
		float time = Random.Range(minWaitTime, maxWaitTime);

		// Random animation
		if(otherAnimations.Count() > 0 && Random.Range(1, 100) < AnimFrequency){
			int animationIndex = Random.Range(0, otherAnimations.Count);
			string anim = otherAnimations[animationIndex];
			PlayAnimation(anim);

			yield return new WaitForSeconds(GetComponent<Animation>()[anim].length);
			PlayAnimation(idleAnimation);

			time = 1.0f;
		}

		yield return new WaitForSeconds(time);
		walk = true;
		PlayAnimation(walkAnimation);
		if(lastTarget != null) transform.LookAt(currentTarget.position);
	}

	/// <summary>
	/// Play the animation.
	/// </summary>
	/// <param name="anim">Animation.</param>
	void PlayAnimation(string anim)
    {
		if(GetComponent<Animation>() != null && GetComponent<Animation>()[anim] != null)
        {
			GetComponent<Animation>().CrossFade(anim);
        }
	}
	#endregion
	void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Enemy")
            Physics.IgnoreCollision(gameObject.GetComponent<CapsuleCollider>(), other.gameObject.GetComponent<CapsuleCollider>());
    }
} // End class

public enum MovementTypes { Follow, Random, Reverse }
