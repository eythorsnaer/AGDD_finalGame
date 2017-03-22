using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour {

	public float speed;
	public Transform player;
	float offset;

	void Start() {
		offset = 0;
	}
	void Update () {
		offset = player.position.x * speed;//Input.GetAxis("Horizontal") * speed;
		GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}
