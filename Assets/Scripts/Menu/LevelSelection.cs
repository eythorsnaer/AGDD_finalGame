using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour {
	public Canvas mainCanvas;
	public Canvas levelSelectionPage1;
	public Canvas levelSelectionPage2;
	public GameController gameController;

	public void Start()
	{
		loadLevelInfo();
	}

	private void loadLevelInfo()
	{
		List<LevelData> data = gameController.getLevels ();

		List<GameObject> buttons = new List<GameObject> ();

		foreach (Transform child in levelSelectionPage1.transform)
		{
			if (child.gameObject.tag == "LevelButton") 
			{
				buttons.Add (child.gameObject);
			}
		}

		foreach (Transform child in levelSelectionPage2.transform)
		{
			if (child.gameObject.tag == "LevelButton") 
			{
				buttons.Add (child.gameObject);
			}
		}

		Debug.Log(data.Count);
		
		foreach (LevelData level in data)
		{
			foreach (Transform child in buttons[level.ID].transform) 
			{
				if (child.gameObject.tag == "CheckMark") 
				{
					RawImage checkmark = child.gameObject.GetComponent<RawImage>();

					if (level.hasBeenCompleted) 
					{
						checkmark.gameObject.SetActive (true);
					} 
					else 
					{
						checkmark.gameObject.SetActive (false);
					}
				}
				else if (child.gameObject.tag == "MapPieceUI") 
				{
					Image mapPiece = child.gameObject.GetComponent<Image>();
					if (level.hasMapPiece) 
					{
						mapPiece.gameObject.SetActive (true);

						if (level.mapPieceWasFound) 
						{
							mapPiece.color = new Color (255, 255, 255, 255);
						} 
						else 
						{
							mapPiece.color = new Color (0, 0, 0, 255);
						}
					} 
					else 
					{
						mapPiece.gameObject.SetActive (false);
					}
				}
			}
		}
	}

	public void openLevelSelection()
	{
		mainCanvas.gameObject.SetActive (false);
		levelSelectionPage1.gameObject.SetActive (true);
	}

	public void openOtherPage()
	{
		if (levelSelectionPage1.gameObject.activeSelf)
		{
			levelSelectionPage1.gameObject.SetActive (false);
			levelSelectionPage2.gameObject.SetActive (true);
		}
		else
		{
			levelSelectionPage2.gameObject.SetActive (false);
			levelSelectionPage1.gameObject.SetActive (true);
		}
	}

	public void closeLevelSelection()
	{
		levelSelectionPage1.gameObject.SetActive (false);
		mainCanvas.gameObject.SetActive (true);
	}
}
