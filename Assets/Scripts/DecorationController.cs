using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int spriteNumber = Random.Range (1, 4);
		string path = "Sprites/Environment/Decorations/Paraphernalia" + spriteNumber.ToString ();
		gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> (path);
	}
}
