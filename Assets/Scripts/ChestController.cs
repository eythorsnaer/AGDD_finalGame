using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour {
	public GameController gameController;
	private Animator anim;
	public AudioClip winClip;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("in trigger");
        if(other.CompareTag("Player")) {
			AudioSource.PlayClipAtPoint(winClip, other.transform.position);
			anim.SetBool("openChest", true);
			Debug.Log("in win trigger");

			
		}



		//gameController.Save();
    }
}
