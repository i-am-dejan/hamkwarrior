using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectDiamond : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            moving.collectedDiamonds++;
            Debug.Log("Collected Diamonds " + moving.collectedDiamonds);
            // MusicSource.Play();
            // collision.gameObject.GetComponent<IncreaseDigit>().increaseNumber();
        }
    }
}
