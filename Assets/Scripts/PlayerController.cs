using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private bool facingRight;
    private bool jump;
    private float maxSpeed = 3f;
    private float jumpForce = 40f;

	// Use this for initialization
	void Start () {
        facingRight = true;
	}

	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.Space))
        {
            jump = true;
            Move(0, jump);
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
        if(Input.GetKeyUp(KeyCode.Space))
        {
            jump = false;
        }
    }

    public void Move(float move, bool jump)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        if(jump)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);

            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
        }
    }
}
