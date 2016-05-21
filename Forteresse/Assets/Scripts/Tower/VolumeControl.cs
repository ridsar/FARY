using UnityEngine;
using System.Collections;

public class VolumeControl : MonoBehaviour {


    public void VolumeCtrl(float volumecontrol)
    {
        GetComponent<AudioSource>().volume = volumecontrol;
    }

}
