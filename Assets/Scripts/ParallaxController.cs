using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour {

	public float speed;
	Transform target;
	float offsetX;
	float offsetY;

	void Start() {
		offsetX = 0;
		offsetY = 0;
		target = Camera.main.transform;
	}
	void Update () {
		offsetX = target.position.x * speed;
		offsetY = target.position.y * speed*3;
		GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));
	}
}
