using UnityEngine;
using System.Collections;

public class Mapcamera : MonoBehaviour {


    public Transform Player;

    void LateUpdate()
    {
        transform.position = new Vector3(Player.position.x, transform.position.y, Player.position.z);
    }
}
