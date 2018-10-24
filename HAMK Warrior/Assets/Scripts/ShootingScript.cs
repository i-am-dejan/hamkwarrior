﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingScript : MonoBehaviour {

    public Transform FirePoint;
    public GameObject bananaPrefab;
    Animator anim;

    // **************
    // UI
    // **************

    //Parameters for UI
    public Button btn_attack;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        Button btn1 = btn_attack.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire3"))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        anim.SetTrigger("isAttacking");
        Invoke("InstantiateBanana", 0.3f);
    }

    void InstantiateBanana()
    {
        Instantiate(bananaPrefab, FirePoint.position, FirePoint.rotation);
    }

    void TaskOnClick ()
    {
        Shoot();
    }
}
