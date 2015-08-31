using UnityEngine;
using System.Collections;

public class StopMoveBoxScript : MonoBehaviour {
	public GameObject startPoint;
	public GameObject endPoint;
	public float speed;
	
	// Attribute
	private bool isMoving; // ntar bisa buat turn on - turn off
	private bool canMove;

	// Use this for initialization
	void Start () {
		// Hide sprite renderer helper points
		startPoint.GetComponent<SpriteRenderer> ().enabled = false;
		endPoint.GetComponent<SpriteRenderer> ().enabled = false;
		
		// Initialize var
		isMoving = true; // set moving true for the first time stage loaded
		canMove = false;
		
		// Set initial position
		transform.position = startPoint.transform.position;
		transform.LookAt (endPoint.transform);
	}
	
	// Update is called once per frame
	void Update () {
		// check if box already reached end point position
		if (isFlipping()) {
			print ("FLIP");
			FlipDirection();
			transform.LookAt (endPoint.transform);
		}
	}

	void FixedUpdate () {
		// check if box is enable to move
		if (isMoving && canMove) {
			if (isFlipping()) {
				FlipDirection();
				print("FLIP");
			}
			MoveBox ();
		}
	}
	
	void OnTriggerEnter (Collider obj) {
		// check if box collide with player
		if (obj.tag == "Player") {
			print("Collide");
			canMove = true;
		}
	}
	
	void OnTriggerExit (Collider obj) {
		// check if box not collide with player
		if (obj.tag == "Player") {
			print("Exit Collide");
			canMove = false;
		}
	}
	
	private void MoveBox () {
		transform.position += transform.forward * speed * Time.deltaTime; 
	}
	
	// method to check if box is flipping or not
	private bool isFlipping () {
		int tempDistance = (int)Vector3.Distance (transform.position, endPoint.transform.position);
		if (tempDistance == 0)
			return true;
		return false;
	}
	
	// flip box to other direction
	private void FlipDirection () {
		Vector3 tempVector = startPoint.transform.position;
		startPoint.transform.position = endPoint.transform.position;
		endPoint.transform.position = tempVector;
	}
	
	// Public method to turn on the box
	public void TurnOn () {}
	// Public method to turn off the box
	public void TurnOff () {}
}
