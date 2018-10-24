using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMenu : MonoBehaviour {

    public GameObject MenuButton;

	public void StartGame ()
    {
        GameObject panel = GameObject.FindGameObjectWithTag("Panel");
        panel.SetActive(false);
        Debug.Log("Close Introdution Panel");
        Time.timeScale = 1.0f;
        MenuButton.SetActive(true);

    }
}
