using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

	public Transform[] backgrounds;
	private float[] parallaxScales;
	private float[] parallaxScalesY;
	public float smoothingX;
	public float smoothingY;

	private Transform cam;
	private Vector3 previousCampPos;
	void Start () {
		cam = Camera.main.transform;
		previousCampPos = cam.position;

		parallaxScales = new float[backgrounds.Length];
		parallaxScalesY = new float[backgrounds.Length];
		int j = 1;

		for (int i = 0; i < backgrounds.Length; i++) {
			parallaxScales[i] = backgrounds[i].position.z * i;
			parallaxScalesY[i] = backgrounds[i].position.z * i * smoothingY;
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {

		for (int i = 0; i < backgrounds.Length; i++) {
			float parallaxX = (previousCampPos.x - cam.position.x) * parallaxScales[i];
			float parallaxY = (previousCampPos.y - cam.position.y) * parallaxScalesY[i];

			Vector3 backgroundsTargetPos = new Vector3(
				backgrounds[i].position.x + parallaxX, 
				backgrounds[i].position.y + parallaxY,
				backgrounds[i].position.z);

			backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundsTargetPos, smoothingX * Time.deltaTime);
		}

		previousCampPos = cam.position;
	}
}
