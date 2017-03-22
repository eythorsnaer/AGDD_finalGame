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
    private float countdown = .2f;

    private CapsuleCollider2D playerCollider;
    private float crouchHeight;
    private float standHeight;
    private float crouchOffset;
    private bool isCrouching;

    // Use this for initialization
    void Start () {
        canJump = true;
        facingRight = true;
        isGrounded = true;
        anim = GetComponent<Animator>();

        playerCollider = GetComponent<CapsuleCollider2D>();
        standHeight = playerCollider.size.y;
        crouchHeight = standHeight / 2;
        crouchOffset = 0.02f;
        isCrouching = false;
    }

	// Update is called once per frame
	void FixedUpdate () {
        isGrounded = Physics2D.Linecast(transform.position - new Vector3(0, .65f, 0), transform.position - new Vector3(0, 1.5f, 0));
        if(isGrounded)
        {
            anim.SetBool("Jumping", false);
        }

        if (((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded) || jump)
        {
            if(isCrouching)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce / 2);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
            }
            
            if(!jump)
            {
                jumpTime = Time.time;
                jumpPressedTime = jumpTime + countdown;
            }
            jump = true;
            anim.SetBool("Jumping", true);
            anim.SetBool("Running", false);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
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
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
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
        if(((Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) && !facingRight) || ((Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) && facingRight))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
            anim.SetBool("Running", false);
        }
        if((Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) || Time.time >= jumpPressedTime) 
        {
            jump = false;
            //GetComponent<Rigidbody2D>().AddForce(new Vector2(0, deceleration));
        }
        if(Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetBool("Crouching", true);
            anim.SetBool("Jumping", false);
            anim.SetBool("Running", false);
            playerCollider.size = new Vector2(playerCollider.size.x, crouchHeight);
            playerCollider.offset = new Vector2(0, crouchOffset);
            isCrouching = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.SetBool("Crouching", false);
            playerCollider.size = new Vector2(playerCollider.size.x, standHeight);
            playerCollider.offset = new Vector2(0, 0);
            isCrouching = false;
        }
    }

    public void Move(float move, bool jump)
    {
        if (isCrouching)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(move * (maxSpeed/2), GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
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
