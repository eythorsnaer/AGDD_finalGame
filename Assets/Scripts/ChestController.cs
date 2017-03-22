using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestController : MonoBehaviour {
	[SerializeField]
	public GameController gameController;
<<<<<<< HEAD
	public LevelController level;
=======
	[SerializeField]
	public Transform winMenu;
	[SerializeField]
	public AudioClip winClip;
>>>>>>> origin/master
	private float timeUntilLoad = 2;
	private bool hasWon = false;
	private Transform player;
	private Animator anim;
	

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update() {
		if (hasWon) {
			if (Input.GetKeyDown(KeyCode.Space)) {
				LoadNextLevel();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
<<<<<<< HEAD
        if(other.CompareTag("Player")) {
			AudioSource.PlayClipAtPoint(winClip, other.transform.position);
			anim.SetBool ("openChest", true);
			level.completedLevel ();
			gameController.Save ();
=======
		if(other.CompareTag("Player")) {
			AudioSource.PlayClipAtPoint(winClip, other.transform.position);
			anim.SetBool("openChest", true);
>>>>>>> origin/master
			hasWon = true;

			player.GetComponent<PlayerController>().enabled = false;
			winMenu.gameObject.SetActive (true);
			gameController.Save ();
			//StartCoroutine(LoadNextLevel(timeUntilLoad));
		}
    }

	public void LoadNextLevel()
	{
		SceneManager.LoadScene (gameController.getCurrentLevelIndex() + 1);
	}

	IEnumerator LoadNextLevel(float time)
	{
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene (gameController.getCurrentLevelIndex() + 1);
	}
}
