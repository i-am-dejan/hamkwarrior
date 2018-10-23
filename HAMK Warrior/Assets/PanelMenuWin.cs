using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelMenuWin : MonoBehaviour {

    public void Retry()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameObject.SetActive(false);
    }

    public void NextLevel()
    {
        Debug.Log("There are no more Levels at the moment.");
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
