﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dying : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void die ()
    {
        Debug.Log("Oh no, you fell to your death.");
        Time.timeScale = 0.0f;
        // Stop Musik
        // Dead screen
    }
}