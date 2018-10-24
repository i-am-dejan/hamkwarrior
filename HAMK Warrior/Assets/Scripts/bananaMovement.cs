using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bananaMovement : MonoBehaviour
{

    public float speed = 3f;
    public Rigidbody2D rb;
    public GameObject player;



    // Use this for initialization
    void Start()
    {



        rb = GetComponent<Rigidbody2D>();

        if (moving.facingRight)
        {
            rb.velocity = transform.right * -speed;
            transform.Rotate(0f, 180f, 0f);

        }
        else
        {
            rb.velocity = transform.right * speed;
            transform.Rotate(0f, 0f, 0f);
        }


    }



    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag == "enemy")
        {
            Debug.Log("BANANA HIT");
            Destroy(gameObject);
            GameObject golem = collision.gameObject;
            Animator golemAnim = golem.GetComponent<Animator>();
            golemAnim.SetTrigger("isDead");
            Destroy(collision.gameObject,1);

        }

        Invoke("Destroy", 3);

        if (collision.transform.tag == "ground" || collision.transform.tag == "Diamonds")
        {
            Debug.Log("BANANA HIT");
            Destroy(gameObject);
        }

    }


    void Destroy()
    {
        Destroy(gameObject);
    }




}
