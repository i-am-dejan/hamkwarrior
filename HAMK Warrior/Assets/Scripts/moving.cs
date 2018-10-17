using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class moving : MonoBehaviour
{
    float MaxSpeed = 8.0f;

    // ****************
    // CHARACTER
    // ****************

    //Parameters for player
    public int jump;
    public bool grounded = false;

    // ****************
    // UI
    // ****************

    //Parameters for UI
    public Button btn_jump;

    // Use this for initialization
    void Start()
    {
        Button btn1 = btn_jump.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // When  user taps Jump-button, player will jump up
    // Grounded bool forces player goes to ground and then they can jump once again (no douple or triple jumps allowed)
    void TaskOnClick()
    {
        Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.Translate(Vector2.up * jump * Time.deltaTime);
        if (grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, jump);
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
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * MaxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        Debug.Log(GetComponent<Rigidbody2D>().position);
    }
}
