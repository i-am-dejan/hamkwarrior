using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightController : MonoBehaviour {
    /*
     * ACCELERATOR
    Rigidbody2D rb;
    float dirX;
    float moveSpeed = 20f;
    */

    float dirX;
    public float moveSpeed = 5f;
    Rigidbody2D rb;
    bool facingRight = true;
    Vector3 localScale;
    Animator anim;
    bool isHurting = false, isDead = false;


    // Use this for initialization
    void Start()
    {
        /* ACCELERATOR
         rb = GetComponent<Rigidbody2D>();
         */

        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /* ACCELERATOR
        dirX = Input.acceleration.x * moveSpeed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7.5f, -7.5f), transform.position.y);
        */

        if (Input.GetButtonDown("Jump") && !isDead && rb.velocity.y == 0)
            rb.AddForce(Vector2.up * 600f);

        SetAnimationState();

        if (!isDead)
            dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
    }

    void FixedUpdate()
    {
        /* ACCELERATOR
        rb.velocity = new Vector2(dirX, 0f);
        */

        if (!isHurting)
            rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    void SetAnimationState()
    {

        if (dirX == 0)
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", true);
        }

        if (rb.velocity.y == 0)
        {
            anim.SetBool("isJumping", false);
        }

        if (Mathf.Abs(dirX) > 0 && rb.velocity.y == 0)
            if (!anim.GetBool("isRunning"))
                anim.SetBool("isRunning", true);
            else
                anim.SetBool("isRunning", false);

        if (rb.velocity.y > 0)
            anim.SetBool("isJumping", true);

        if (rb.velocity.y < 0)
        {
            anim.SetBool("isJumping", false);
        }

    }

    void LateUpdate()
    {
        CheckWhereToFace();
    }

    void CheckWhereToFace()
    {
        if (dirX < 0)
            facingRight = true;
        else if (dirX > 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }


}
