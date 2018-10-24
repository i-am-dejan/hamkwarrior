using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndGame : MonoBehaviour
{

    public GameObject player;
    public GameObject panel;
    public AudioClip MusicClip;
    public AudioSource MusicSource;
    public AudioSource BackgroundSound;
    public GameObject buttonleft;
    public GameObject buttonright;
    private bool stopUpdate = false;

    // Use this for initialization
    void Start()
    {
        MusicSource.clip = MusicClip;
    }

    // Update is called once per frame
    void Update()
    {
        // Ensure that the Update() method only run once 
        if (!stopUpdate == false)
        {
            return;
        }

        // Ensure that Player end the Game after overlappng with the door 
        if ((player.transform.position.x >= 187.5400 && player.transform.position.x <= 187.7700) && (player.transform.position.y >= -1.55500 && player.transform.position.y <= -1.47000))
        {
            Debug.Log("You are a winner");
            stopUpdate = true;
            BackgroundSound.Stop();
            player.GetComponent<Rigidbody2D>().gravityScale = 400.0f;
            buttonleft.SetActive(false);
            buttonright.SetActive(false);
            MusicSource.Play();
            //StartCoroutine(timer());
            Time.timeScale = 0.0f;
            panel.SetActive(true);
            //player.GetComponent<moving>().IsGameable = false;
        }
    }

    IEnumerator timer()
    {
        Debug.Log("Information table is enabled for 4 sec");
        yield return new WaitForSeconds(4);
        Debug.Log("five seconds later...");
        Time.timeScale = 0.0f;
        panel.SetActive(true);
        //player.GetComponent<moving>().IsGameable = true;
    }
}
