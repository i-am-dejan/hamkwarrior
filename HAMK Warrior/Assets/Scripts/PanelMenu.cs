using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMenu : MonoBehaviour {
 

	public void StartGame ()
    {
        GameObject panel = GameObject.FindGameObjectWithTag("Panel");
        panel.active = false;
        Debug.Log("Button gedrückt.");
        // Time.timeScale = 1.0f;
        //Panel.GetComponentInChildren<Image>().enabled = false;
        //Panel.renderer.enabled = false;
    }
}
