using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour {

	public void Play() {
		SceneManager.LoadScene (1);
	}
}
