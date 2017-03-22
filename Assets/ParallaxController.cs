using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour {

	public float speed;
	Transform target;
	float offset;

	void Start() {
		offset = 0;
		target = Camera.main.transform;
	}
	void Update () {
		offset = target.position.x * speed;
		GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}
