﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {
	/*
	public Transform canvas;
	public Transform player;
	public Transform planet;
	public Transform pauseMenu;
	public Transform controlsMenu;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Pause ();
		}
	}

	public void Pause() {
		if (canvas.gameObject.activeInHierarchy == false) {
			if (pauseMenu.gameObject.activeInHierarchy == false) {
				pauseMenu.gameObject.SetActive (true);
				controlsMenu.gameObject.SetActive (false);
			}

			canvas.gameObject.SetActive (true);
			Time.timeScale = 0;
			player.GetComponent<PlayerController> ().enabled = false;
			player.GetComponent<GravityBody> ().enabled = false;
			planet.GetComponent<GravityAttractor> ().enabled = false;

		} else {
			canvas.gameObject.SetActive (false);
			Time.timeScale = 1;
			player.GetComponent<PlayerController> ().enabled = true;
			player.GetComponent<GravityBody> ().enabled = true;
			planet.GetComponent<GravityAttractor> ().enabled = true;
		}
	}

	public void Exit() {
		Application.Quit();
		//UnityEditor.EditorApplication.isPlaying = false;
	}

	public void Mute() {
		BackgroundMusic.Instance.Mute (); 
	}

	public void Controls(bool Open) {
		if (Open) {
			controlsMenu.gameObject.SetActive (true);
			pauseMenu.gameObject.SetActive (false);
		} else {
			controlsMenu.gameObject.SetActive (false);
			pauseMenu.gameObject.SetActive (true);
		}
	}
	*/
}