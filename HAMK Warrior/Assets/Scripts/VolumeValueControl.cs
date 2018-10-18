using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValueControl : MonoBehaviour
{

    private AudioSource audioSrc;
    public float musicVolumeStart = 0.64f;

    // Use this for initialization
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = musicVolumeStart;
    }

    // Takes Volume value passed by slider
    public void SetVolume(float vol)
    {
        musicVolumeStart = vol;
        VolumeHandler.getInstance().setVolume(musicVolumeStart);
    }

    public float getVolume()
    {
        return musicVolumeStart;
    }

}
