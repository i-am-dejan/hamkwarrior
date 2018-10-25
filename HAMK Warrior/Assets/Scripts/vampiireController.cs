using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vampiireController : MonoBehaviour {

    public float speed = 3;
    private bool movingRight = true;
    public Transform groundDetection;
    Animator anim;
    public float attackRange;
    public int damage = 1;
    private float lastAttackTime;
    public float attackDelay;
    public Transform target;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (!moving.isDead)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }


        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);

        if (!groundInfo.collider)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = true;
            }
        }

        // Check the distance between player and enemy to see if the player is close enough to attack
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        if (distanceToPlayer < attackRange)
        {
            // Check to see if enough time has passed since we last attacked
            if (Time.time > lastAttackTime + attackDelay)
            {
                //target.SendMessage("TakeDamage", damage);

                //anim.SetBool("isAttacking", true);
                if (!moving.isDead)
                {
                    anim.SetTrigger("isAttacking2");
                }

                // Record the time we attack
                lastAttackTime = Time.time;
            }

        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Golem collides with: " + collision.transform.tag);
        if (collision.gameObject.name != "Player")
        {
            Debug.Log("GOLEM IS TURNING AROUND");
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = true;
            }
        }

    }



}
