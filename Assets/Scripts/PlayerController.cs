using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class PlayerController : MonoBehaviour
{
	[HideInInspector]
	public bool facingRight = true;
	[HideInInspector]
	public bool jump = false;
	public LevelController level;

	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public AudioClip[] jumpClips;
	public float jumpForce;
	public AudioClip fallClip;
	public int yMin;

	private Transform groundCheck;
	private bool grounded = false;
	private bool crouching = false;
	private Animator anim;

	private CapsuleCollider2D playerCollider;
    private float crouchHeight;
    private float standHeight;
    private float crouchOffset;

	private bool isRestarting;
	private bool wallE;

	void Awake()
	{
		groundCheck = transform.Find("groundCheck");
		anim = GetComponent<Animator>();
		playerCollider = GetComponent<CapsuleCollider2D>();

		standHeight = playerCollider.size.y;
		crouchHeight = standHeight/2;
		crouchOffset = 0.02f;
		isRestarting = false;
	}


	void Update()
	{
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.OverlapCircle(groundCheck.position, 0.65f, 1 << LayerMask.NameToLayer("Ground"));
		wallE = Physics2D.OverlapCircle(transform.position, 0.35f, 1 << LayerMask.NameToLayer("Wall"));
		
		// If the jump button is pressed and the player is grounded then the player should jump.
		if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && grounded) {
			jump = true;
			anim.SetBool("Jumping", true);
			anim.SetBool("Running", false);
		} else if (!grounded) {
			anim.SetBool("Jumping", true);
			anim.SetBool("Running", false);
		} else {
			anim.SetBool("Jumping", false);
		}

		if(!crouching && grounded && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.DownArrow))) {
            Crouch();
        }
 
		if(crouching && (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.DownArrow))) {
        	StandUp(); 
        }

		if (!isRestarting && (gameObject.GetComponent<Transform> ().position.y <= yMin))
		{
			isRestarting = true;
			AudioSource.PlayClipAtPoint(fallClip, transform.position);
			StartCoroutine(waitAndRestart(0.8f));
		}
	}

	void FixedUpdate ()
	{
		float h = Input.GetAxis("Horizontal");

		if (h >= 0.1 || h <= -0.1) {
			anim.SetBool("Running", true);
		} else {
			anim.SetBool("Running", false);
		}

		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * GetComponent<Rigidbody2D>().velocity.x <= maxSpeed) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveForce * h * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);//AddForce(Vector2.right * h * moveForce);
		}

		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed) {
			// ... set the player's velocity to the maxSpeed in the x axis.
			GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}

		// If the input is moving the player right and the player is facing left...
		if(h > 0 && !facingRight) {
			Flip();
		}
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(h < 0 && facingRight) {
			Flip();
		}

		// If the player should jump...
		if(jump) {
			// Play a random jump audio clip.
			int i = Random.Range(0, jumpClips.Length);
			AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);

			// Add a vertical force to the player.
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);//.AddForce(new Vector2(0f, jumpForce));

			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}

	}
	
	
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


	void Crouch() {
		crouching = true;
		anim.SetBool("Crouching", true);
		anim.SetBool("Jumping", false);
		anim.SetBool("Running", false);

        playerCollider.size = new Vector2 (playerCollider.size.x, crouchHeight);
        playerCollider.offset = new Vector2 (0, crouchOffset);
	}

	void StandUp () {
		crouching = false;
		anim.SetBool("Crouching", false);

		playerCollider.size = new Vector2 (playerCollider.size.x, standHeight);
        playerCollider.offset = new Vector2 (0, 0);
	}

	IEnumerator waitAndRestart(float s) {
        yield return new WaitForSeconds(s);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
    }
}
