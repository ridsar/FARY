using UnityEngine;
using System.Collections;

public class InvokSkeleton : MonoBehaviour
{
    public GameObject skeleton;
    float time = 15;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(time < 0)
        {
            Invoke("invok", 0);
            time = 15;
        }
        else
        {
            time -= 1 * Time.deltaTime;
        }
	}
    void invok()
    {
        GameObject Skeleton1 = Instantiate(skeleton);
        GameObject Skeleton2 = Instantiate(skeleton);

        Skeleton1.name = gameObject.name[0] + Skeleton1.name;
        Skeleton2.name = gameObject.name[0] + Skeleton2.name;

        Skeleton1.transform.parent = transform;
        Skeleton2.transform.parent = transform;

        Skeleton1.transform.localPosition = new Vector3(2f, 0, 5);
        Skeleton2.transform.localPosition = new Vector3(-2f, 0, 5);

        Skeleton1.GetComponent<FollowPath>().index = transform.GetComponent<FollowPath>().index - 1;
        Skeleton2.GetComponent<FollowPath>().index = transform.GetComponent<FollowPath>().index - 1;

        Skeleton1.transform.parent = null;
        Skeleton2.transform.parent = null;

        GameObject.Find("Spawn").transform.FindChild("" + gameObject.name[0]).GetComponent<Spawn>().myEnemy.Add(Skeleton1);
        GameObject.Find("Spawn").transform.FindChild("" + gameObject.name[0]).GetComponent<Spawn>().myEnemy.Add(Skeleton2);


    }
}
