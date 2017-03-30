using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

	private Transform cam;

	void Awake ()
	{
		cam = Camera.main.transform;
	}

	void Update ()
	{
		
		transform.position = new Vector3(cam.position.x, cam.position.y, transform.position.z);
	}
}
