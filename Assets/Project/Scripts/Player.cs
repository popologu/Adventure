using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	[Header("Visual")]
	public GameObject model;

	[Header("Movement")]
	public float movingVelocity;
	public float jumpingVelocity;

	private Rigidbody playerRigidbody;
	private bool canJump = false;

	// Use this for initialization
	void Start () {
		playerRigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		RaycastHit hit;
	 	if	(Physics.Raycast(transform.position, Vector3.down, out hit, 1f)) {
			 canJump = true;
	 	}

		ProcessInput ();
	}

	void OnCollisionEnter(Collision collision) {
		if(collision.transform.tag == "Floor") {
			canJump = true;
		}
	}

	void ProcessInput () {
			playerRigidbody.velocity = new Vector3 (
			0,
			playerRigidbody.velocity.y,
			0
		);

		if (Input.GetKey("right")) {
				playerRigidbody.velocity = new Vector3 (
				movingVelocity,
				playerRigidbody.velocity.y,
				playerRigidbody.velocity.z
			);

			model.transform.localEulerAngles = new Vector3 (0,270,0);
		}
		if (Input.GetKey("left")) {
				playerRigidbody.velocity = new Vector3 (
				-movingVelocity,
				playerRigidbody.velocity.y,
				playerRigidbody.velocity.z
			);
			model.transform.localEulerAngles = new Vector3 (0,90,0);
		}
		if (Input.GetKey("up")) {
				playerRigidbody.velocity = new Vector3 (
				playerRigidbody.velocity.x,
				playerRigidbody.velocity.y,
				movingVelocity
			);
			model.transform.localEulerAngles = new Vector3 (0,180,0);
		}
		if (Input.GetKey("down")) {
				playerRigidbody.velocity = new Vector3 (
				playerRigidbody.velocity.x,
				playerRigidbody.velocity.y,
				-movingVelocity
			);
			model.transform.localEulerAngles = new Vector3 (0,0,0);
		}
		if (Input.GetKeyDown("space") && canJump) {
			canJump = false;
			// GetComponent<Rigidbody> ().AddForce(0, jumpingVelocity,0);
				playerRigidbody.velocity = new Vector3 (
				playerRigidbody.velocity.x,
				jumpingVelocity,
				playerRigidbody.velocity.z
			);
		}
	}
}
  