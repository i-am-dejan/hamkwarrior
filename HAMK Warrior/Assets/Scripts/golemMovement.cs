using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golemMovement : MonoBehaviour {

    public LayerMask golemMask;
    Rigidbody2D rb;
    Transform myTrans;
    float myWidth;
    public float speed;

	// Use this for initialization
	void Start () {
        myTrans = this.transform;
        rb = this.GetComponent<Rigidbody2D>();
        myWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x;
	}


    void FixedUpdate()
    {
        Vector2 lineCastPos = myTrans.position - myTrans.right * myWidth;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);

        Vector2 myVel = rb.velocity;
        myVel.x = speed;
        rb.velocity = myVel;
    }
}
