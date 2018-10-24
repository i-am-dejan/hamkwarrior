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

    // Use this for initialization
    void Start()
    {
        MusicSource.clip = MusicClip;
    }

    // Update is called once per frame
    void Update()
    {
        /** For Debugging Reasons **/
        //Debug.Log("Door:" + gameObject.transform.position.x);
        //Debug.Log("Player:" + player.transform.position.y);
        if ((player.transform.position.x >= 187.5500 && player.transform.position.x <= 187.7600) && (player.transform.position.y >= -1.55500 && player.transform.position.y <= -1.47000))
        {
            MusicSource.Play();
            BackgroundSound.Stop();
            Debug.Log("You are a winner");
            //Time.timeScale = 0.0f;
            panel.SetActive(true);
        }

    }
}
