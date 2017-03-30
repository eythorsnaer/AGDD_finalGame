using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {
	public enum GravityDirection {UP, DOWN, NONE};
	public enum BlockType {Falling, Hovering, Static, Bouncing, InOut, Icy};
	public BlockType blockType;
	public GravityDirection gravityDirection;
	private bool moving;
	private bool hasGravity;
	public float fallDelay;
	private float OFF_SCREEN_Y_POSITION_LOWER = -9;
	private float OFF_SCREEN_Y_POSITION_UPPER = 9;

	// Use this for initialization
	void Start () {
		moving = false;
		hasGravity = false;

		if (blockType == BlockType.Falling) 
		{
			int spriteNumber = Random.Range (1, 7);
			string path = "Sprites/Environment/Blocks/FallingBlock" + spriteNumber.ToString ();
			gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> (path);
		} 
		else if (blockType == BlockType.Static) 
		{
			int spriteNumber = Random.Range (1, 4);
			string path = "Sprites/Environment/Blocks/StaticBlock" + spriteNumber.ToString ();
			gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> (path);
		}
		else if (blockType == BlockType.Icy) {
			
		}
		else if (blockType == BlockType.Bouncing)
		{

		}
	}

	// Update is called once per frame
	void Update () 
	{
		if (gravityDirection != GravityDirection.NONE && !hasGravity && moving && fallDelay > 0) 
		{
			fallDelay -= Time.deltaTime;
		} 
		else if (gravityDirection != GravityDirection.NONE && !hasGravity && moving && fallDelay <= 0) 
		{
			hasGravity = true;
			if (gravityDirection.Equals(GravityDirection.DOWN))
			{
				gameObject.GetComponent<Rigidbody2D> ().gravityScale = 1;
			}
			else
			{
				gameObject.GetComponent<Rigidbody2D> ().gravityScale = -1;
			}

			gameObject.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
		}

		if (gravityDirection != GravityDirection.NONE && gameObject.GetComponent<Transform> ().position.y <= OFF_SCREEN_Y_POSITION_LOWER) 
		{
			Destroy (gameObject);
		} 
		else if (gravityDirection != GravityDirection.NONE && gameObject.GetComponent<Transform> ().position.y >= OFF_SCREEN_Y_POSITION_UPPER) 
		{
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (gravityDirection != GravityDirection.NONE) 
		{
			moving = true;
		}
		
	}
}
