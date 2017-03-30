using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingController : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			Debug.Log("baaa");
			anim.SetTrigger("Jump");
		}
	}


}
