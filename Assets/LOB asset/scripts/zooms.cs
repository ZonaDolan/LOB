using UnityEngine;
using System.Collections;

public class zooms : MonoBehaviour {
	private bool zoomz;
	// Use this for initialization
	void Start () {
		zoomz = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.Z) && zoomz== false) {
			gameObject.transform.position += new Vector3(0, 0, -15);
			zoomz = true;
		} else if (Input.GetKeyDown(KeyCode.Z) && zoomz == true) {
			gameObject.transform.position += new Vector3(0, 0, 15);
			zoomz = false;
		}
	}
}
