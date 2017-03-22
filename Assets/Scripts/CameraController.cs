﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	 public float dampTime = 0.15f;
     private Vector3 velocity = Vector3.zero;
     public Transform target;

	// Use this for initialization
	void Start () {
        Screen.SetResolution(1920, 1080, true);
    }
 
     // Update is called once per frame
     void Update () 
     {
         if (target)
         {
             Vector3 point = Camera.WorldToViewportPoint(target.position);
             Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
             Vector3 destination = transform.position + delta;
             transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
         }
	 }
}
