using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private bool facingRight;
    private bool jump;
    private bool canJump;
    private float maxSpeed = 3f;
    private float jumpForce = 10f;
    private float deceleration = -100f;
    private Animator anim;
    private bool isGrounded;
    private float jumpTime = 0;
    private float jumpPressedTime = 0;
    private float countdown = .3f;


	// Use this for initialization
	void Start () {
        canJump = true;
        facingRight = true;
        isGrounded = true;
        anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void FixedUpdate () {
        isGrounded = Physics2D.Linecast(transform.position - new Vector3(0, .65f, 0), transform.position - new Vector3(0, 1f, 0));
        if(isGrounded)
        {
            anim.SetBool("Jumping", false);
        }

        if ((Input.GetKeyDown(KeyCode.Space) && isGrounded) || jump)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, deceleration));
            if(!jump)
            {
                jumpTime = Time.time;
                jumpPressedTime = jumpTime + countdown;
            }
            jump = true;
            anim.SetBool("Jumping", true);
            anim.SetBool("Running", false);
        }
        if(Input.GetKey(KeyCode.A))
        {
            Move(-1f, jump);
            if(facingRight)
            {
                Flip();
            }
            if(isGrounded)
            {
                anim.SetBool("Running", true);
            }
            
        }
        if(Input.GetKey(KeyCode.D))
        {
            Move(1f, jump);
            if (!facingRight)
            {
                Flip();
            }
            if (isGrounded)
            {
                anim.SetBool("Running", true);
            }
        }
        if((Input.GetKeyUp(KeyCode.A) && !facingRight) || (Input.GetKeyUp(KeyCode.D) && facingRight))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
            anim.SetBool("Running", false);
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

    void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
