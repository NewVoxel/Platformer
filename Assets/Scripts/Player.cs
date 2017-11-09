using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private Rigidbody rb = new Rigidbody ();
	private float playerHeight;
	public float movementSpeed = 5f;
	public float jumpHeight = 300f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		playerHeight = GetComponent<CapsuleCollider> ().height;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 targetVelocity = new Vector3 (0, rb.velocity.y, rb.velocity.z);

		if (Input.GetKey ("right") || Input.GetKey("d")) {
			targetVelocity = new Vector3 (movementSpeed, rb.velocity.y, rb.velocity.z);
		}
		if(Input.GetKey("left") || Input.GetKey("a")) {
			targetVelocity = new Vector3 (-movementSpeed, rb.velocity.y, rb.velocity.z);
		}

		rb.velocity = targetVelocity;

		RaycastHit hit;
		if (Physics.Raycast (this.transform.position, Vector3.down, out hit, (playerHeight / 2f) + 0.001f)) {
			if(Input.GetKeyDown("w") || Input.GetKeyDown("up") || Input.GetKeyDown("space"))
				rb.AddForce (Vector3.up * jumpHeight);
		}
	}
}
