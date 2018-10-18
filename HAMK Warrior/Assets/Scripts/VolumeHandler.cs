using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeHandler {

    private float Volume = 0.64f;
    private static VolumeHandler instance = null;

    public static VolumeHandler getInstance()
    {
        if (instance == null) {
            instance = new VolumeHandler();
        }
        return instance;
    }

    public void setVolume(float volume)
    {
        this.Volume = volume;
    }

    public float getVolume()
    {
        return Volume;
    }
}
