using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {
	[SerializeField]
	public Transform canvas;

	private Transform player;
	[SerializeField]
	public Transform pauseMenu;
	[SerializeField]
	public Transform controlsMenu;

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player").transform;

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			PauseResume ();
		} else if (Input.GetKeyDown (KeyCode.R)) {
			 SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	public void PauseResume() {
		if (canvas.gameObject.activeInHierarchy == false) {
			if (pauseMenu.gameObject.activeInHierarchy == false) {
				pauseMenu.gameObject.SetActive (true);
				controlsMenu.gameObject.SetActive (false);
			}

			canvas.gameObject.SetActive (true);
			Time.timeScale = 0;
			player.GetComponent<PlayerController> ().enabled = false;
		} else {
			canvas.gameObject.SetActive (false);
			Time.timeScale = 1;
			player.GetComponent<PlayerController> ().enabled = true;
		}
	}

	public void MainMenuControlls() {
		if (controlsMenu.gameObject.activeInHierarchy == false) {
			controlsMenu.gameObject.SetActive (true);
		} else {
			controlsMenu.gameObject.SetActive (false);
			Debug.Log("baaa");
		}
	}

	public void ExitToMainMenu() {
		SceneManager.LoadScene (0);
		//Application.Quit();
		//UnityEditor.EditorApplication.isPlaying = false;
	}

	public void Mute() {
		BackgroundMusic.Instance.Mute (); 
	}

	public void ControlsMenu() {
		controlsMenu.gameObject.SetActive (true);
		pauseMenu.gameObject.SetActive (false);
	}
}
