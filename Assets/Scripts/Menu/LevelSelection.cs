using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour {
	public Canvas mainCanvas;
	public Canvas levelSelection;

	public void openLevelSelection()
	{
		mainCanvas.gameObject.SetActive (false);
		levelSelection.gameObject.SetActive (true);
	}

	public void closeLevelSelection()
	{
		levelSelection.gameObject.SetActive (false);
		mainCanvas.gameObject.SetActive (true);
	}
}
