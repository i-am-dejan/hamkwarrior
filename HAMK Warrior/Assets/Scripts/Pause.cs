using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    //Pause-settings
    //Parameters for buttons and texts
    public Button PauseButton; //hide the pausebutton when PauseMenu-panel is active
    public GameObject pausePanel;
    public Button ContinueButton;
    public GameObject hearts;
    public Button TutorialButton;
    public Button RetryGameButton;
    public Button EndGameButton;

    //set pausepanel and child objects visible
    //link buttons to addlistener component and their methods
    void Start()
    {
        hearts.gameObject.SetActive(true);
        pausePanel.SetActive(false);
        Button btn1 = PauseButton.GetComponent<Button>(); //open PauseMenu
        btn1.onClick.AddListener(PauseMenu);

        Button btn2 = ContinueButton.GetComponent<Button>(); //Continue gaming
        btn2.onClick.AddListener(ContinueGame);

        Button btn3 = ContinueButton.GetComponent<Button>(); //Show tutorial
        btn3.onClick.AddListener(showTutorial);

        Button btn4 = ContinueButton.GetComponent<Button>(); //Retry game
        btn4.onClick.AddListener(RetryGame);

        Button btn5 = ContinueButton.GetComponent<Button>(); //End game
        btn5.onClick.AddListener(EndGame);
    }

    //pauses game
    //Makes PauseButton disappear
    //Freezes game
    void PauseMenu()
    {
        hearts.gameObject.SetActive(false);
        PauseButton.gameObject.SetActive(false);
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }


    //vanish pausepanel and all the child objects
    //continue gaming
    //set visibility back to pausebutton
    private void ContinueGame()
    {
        hearts.gameObject.SetActive(true);
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        PauseButton.gameObject.SetActive(true);
    }

    //remember make the parameter for the button
    private void showTutorial()
    {
        //show tutorial
    }

    //remember make the parameter for the button
    private void RetryGame()
    {
        //go back to mainmenu
    }

    //remember make the parameter for the button
    private void EndGame()
    {
        //SceneManager.LoadScene(sceneBuildIndex:0);
    }
}