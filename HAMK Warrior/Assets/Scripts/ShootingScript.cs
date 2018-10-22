using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour {

    public Transform FirePoint;
    public GameObject bananaPrefab;
    Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
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
}
