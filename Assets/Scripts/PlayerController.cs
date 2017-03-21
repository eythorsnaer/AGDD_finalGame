using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private bool facingRight;
    private bool jump;
    private bool canJump;
    private float maxSpeed = 3f;
    private float jumpForce = 8f;
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
	void Update () {
        isGrounded = Physics2D.Linecast(transform.position - new Vector3(0, .65f, 0), transform.position - new Vector3(0, 0.7f, 0));

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
            jumpTime = Time.time;
            jumpPressedTime = jumpTime + countdown;
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
        if(Input.GetKeyUp(KeyCode.Space)) //Temporary, needs a ground check
        {
            jump = false;
        }
    }

    public void Move(float move, bool jump)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }

    public void checkGround()
    {
        isGrounded = Physics.Raycast(transform.position, Vector2.down, 1000f);
    }
}
