using UnityEngine;
using System.Collections;

public class MovingBoxScript : MonoBehaviour {
	public GameObject startPoint;
	public GameObject endPoint;
	public float speed;

	// Attribute
	private bool isMoving; // ntar bisa buat turn on - turn off

	// Use this for initialization
	void Start () {
		// Hide sprite renderer helper points
		startPoint.GetComponent<SpriteRenderer> ().enabled = false;
		endPoint.GetComponent<SpriteRenderer> ().enabled = false;

		// Initialize var
		isMoving = true; // set moving true for the first time stage loaded
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
		if(isMoving) MoveBox ();
	}

	private void MoveBox () {
//		float velo = Mathf.PingPong (Time.time * speed, 1f);
//		transform.position = Vector3.Lerp (startPoint.transform.position, endPoint.transform.position, velo);
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
