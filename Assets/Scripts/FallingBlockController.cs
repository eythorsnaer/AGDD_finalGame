using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlockController : MonoBehaviour {

	private bool falling;
	private bool hasGravity;
	public float fallDelay;
	private float OFF_SCREEN_Y_POSITION = -9;

	// Use this for initialization
	void Start () {
		falling = false;
		hasGravity = false;
	}

	// Update is called once per frame
	void Update () 
	{
		if (!hasGravity && falling && fallDelay > 0) 
		{
			fallDelay -= Time.deltaTime;
		} 
		else if (!hasGravity && falling && fallDelay <= 0) 
		{
			hasGravity = true;
			gameObject.GetComponent<Rigidbody2D> ().gravityScale = 1;
			gameObject.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionX;
		}

		if (gameObject.GetComponent<Transform> ().position.y <= OFF_SCREEN_Y_POSITION) 
		{
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		falling = true;
	}
}
