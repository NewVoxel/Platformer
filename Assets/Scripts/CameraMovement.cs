using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public Vector3 offset;
	public GameObject target;
	public float cameraSpeed;

	// Use this for initialization
	void Start () {
		offset = new Vector3 (0f, 1.5f, -7f);
		target = GameObject.FindGameObjectWithTag ("Player");
		cameraSpeed = 0.1f;
	}

	// Update is called once per frame
	void FixedUpdate () {
		transform.position = Vector3.Lerp (transform.position, target.transform.position + offset, cameraSpeed);
	}
}
