﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 0.0f;
        moving.collectedDiamonds = 0;
        moving.collectedDiamondsTotally = 0;

    }

    public void QuitGame ()
    {
        Debug.Log("Quit the Game!");
        Application.Quit();
    }

}
