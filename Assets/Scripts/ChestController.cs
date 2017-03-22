using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestController : MonoBehaviour {
	public GameController gameController;
	private Animator anim;
	public AudioClip winClip;
	private float timeUntilLoad = 2;
	private bool hasWon = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	void Update()
	{
		if (hasWon) 
		{
			timeUntilLoad -= Time.deltaTime;

			if (timeUntilLoad <= 0)
			{
				SceneManager.LoadScene (gameController.getCurrentLevelIndex() + 2);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("in trigger");
        if(other.CompareTag("Player")) {
			AudioSource.PlayClipAtPoint(winClip, other.transform.position);
			anim.SetBool("openChest", true);
			Debug.Log("in win trigger");

			gameController.Save ();
			hasWon = true;
		}
		//gameController.Save();
    }
}
