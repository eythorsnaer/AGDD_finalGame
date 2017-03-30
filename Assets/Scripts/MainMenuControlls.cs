using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControlls : MonoBehaviour {
	public Transform controlsMenu;

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			controlsMenu.gameObject.SetActive (false);
		} 
	}

	public void toggleControlls() {
		if (controlsMenu.gameObject.activeInHierarchy == false) {
			controlsMenu.gameObject.SetActive (true);
		} else {
			controlsMenu.gameObject.SetActive (false);

		}
	}

}
