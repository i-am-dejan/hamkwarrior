using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour {
    float MaxSpeed = 8.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * MaxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        Debug.Log(GetComponent<Rigidbody2D>().position);
    }
}
