using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setVolumeForLevel : MonoBehaviour
{

    private AudioSource audioSrc;
    public GameObject obj;

    // Use this for initialization
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = VolumeHandler.getInstance().getVolume();
    }
}
