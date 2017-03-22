using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControlls : MonoBehaviour {
	public Transform controlsMenu;

	public void toggleControlls() {
		if (controlsMenu.gameObject.activeInHierarchy == false) {
			controlsMenu.gameObject.SetActive (true);
		} else {
			controlsMenu.gameObject.SetActive (false);
			Debug.Log("baaa");
		}
	}

}
