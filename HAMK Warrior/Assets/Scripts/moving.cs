using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class moving : MonoBehaviour
{
    float MaxSpeed = 8.0f;

    // ****************
    // CHARACTER
    // ****************

    //Parameters for player
    Rigidbody2D rb;
    public int jump = 10;
    float dirX;
    public static bool facingRight = true;
    Vector3 localScale;
    public bool grounded = false;
    Animator anim;
    private int speed = 4;  //this is player's maxspeed that they won't slide throught the objects
    public int health = 3;
    private float lastAttackTime;
    public float attackDelay;
    public static bool isDead = false;

    // ****************
    // UI
    // ****************

    //Parameters for UI
    public Button btn_jump;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Button btn1 = btn_jump.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClick);
        localScale = transform.localScale;
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    // When user tilts phone, player will go forward or backward (depends where user tilts phone)
    void Update()
    {
        {
            dirX = 0;
            Vector3 dir = Vector3.zero;
            dir.x = Input.acceleration.x;
            dirX = dir.x;
            // Clamp acceleration vector to unit sphere 
            if (dir.sqrMagnitude > 1)
            {
                dir.Normalize();
            }
            // Make it move 10 meters per second instead of 10 meters per frame...
            dir *= Time.deltaTime;

            //Move object
            //normally you don't use minus in dir but in this project it was needed that player will go forward when phone is tilted to right
            if (!isDead)
            {
                transform.Translate(-dir * speed);
            }
        }

        /* --------------------------------------------------- */
        /* DELETE THIS - TESTING PURPOSES ONLY */
        float move = Input.GetAxis("Horizontal");

        dirX = move * MaxSpeed;
        if (!isDead) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(move * MaxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        /* --------------------------------------------------- */

        if (dirX != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        CheckWhereToFace();
    }






    // When  user taps Jump-button, player will jump up
    // Grounded bool forces player goes to ground and then they can jump once again (no douple or triple jumps allowed)
    void TaskOnClick()
    {
        Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.Translate(Vector2.up * jump * Time.deltaTime);
        if (grounded)
        {
            //anim.SetBool("isRunning", false);
            anim.SetTrigger("isJumping");
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, jump);
            // rb.AddForce(Vector2.up * 600f);
            grounded = false;
        }
    }

    // ****************
    //Collision
    // ****************
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If player collided objects which have tag named:"Ground", make grounded-value true
        if (collision.transform.tag == "ground")
        {
            grounded = true;
        }
        if (collision.transform.tag == "bluediamond")
        {
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag == "enemy")
        {
            if (Time.time > lastAttackTime + attackDelay)
            {
                Debug.Log("HUUUUUUUUUUUUUUUUUUUUUUUURT");
                if (health > 1)
                {
                    anim.SetTrigger("isHurt");
                }
                TakeDamage(1);
                lastAttackTime = Time.time;
            }

        }
    }

    //void FixedUpdate()
    //{
    //    float move = Input.GetAxis("Horizontal");
    //    GetComponent<Rigidbody2D>().velocity = new Vector2(move * MaxSpeed, GetComponent<Rigidbody2D>().velocity.y);
    //    Debug.Log(GetComponent<Rigidbody2D>().position);
    //}

    void CheckWhereToFace()
    {
        if (dirX < 0)
            facingRight = false;
        else if (dirX > 0)
            facingRight = true;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;
        Debug.Log("Health = " + health);
        if (health <= 0)
        {
            isDead = true;
            anim.SetTrigger("isDead");
            Invoke("MainMenu", 0.8f);
        }
    }

    public void MainMenu()
    {
        isDead = false;
        // timer
        // game over screen
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
}
