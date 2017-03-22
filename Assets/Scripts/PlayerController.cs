using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private bool facingRight;
    private bool jump;
    private bool canJump;
    private float maxSpeed = 3f;
    private float jumpForce = 6f;
    private Animator anim;
    private bool isGrounded;
    private float jumpTime = 0;
    private float jumpPressedTime = 0;
    private float countdown = .55f;


	// Use this for initialization
	void Start () {
        canJump = true;
        facingRight = true;
        anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void FixedUpdate () {
        isGrounded = Physics2D.Linecast(transform.position - new Vector3(0, .65f, 0), transform.position - new Vector3(0, 1f, 0));

        if ((Input.GetKeyDown(KeyCode.Space) && isGrounded) || jump)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
            if(!jump)
            {
                jumpTime = Time.time;
                jumpPressedTime = jumpTime + countdown;
            }
            jump = true;
        }
        if(Input.GetKey(KeyCode.A))
        {
            Move(-1f, jump);
            facingRight = false;
        }
        if(Input.GetKey(KeyCode.D))
        {
            Move(1f, jump);
            facingRight = true;
        }
        if((Input.GetKeyUp(KeyCode.A) && !facingRight) || (Input.GetKeyUp(KeyCode.D) && facingRight))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        }
        if(Input.GetKeyUp(KeyCode.Space) || Time.time >= jumpPressedTime) 
        {
            jump = false;
        }
    }

    public void Move(float move, bool jump)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }
}
