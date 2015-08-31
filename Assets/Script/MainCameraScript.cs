using UnityEngine;
using System.Collections;

public class MainCameraScript : MonoBehaviour {

	public Transform followingPosition;

	private float sizeCamera;
	private Camera kamera;
	private float zNow;
	
	
	private Vector3 velocity = Vector3.zero;

	void Awake () {
		kamera = GetComponent<Camera>();
		zNow = sizeCamera = transform.position.z;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		/*if (Mathf.Abs(kamera.fieldOfView - sizeCameraNow) < 0.1)
			kamera.fieldOfView = sizeCameraNow;
		else 
			kamera.fieldOfView = Mathf.Lerp(
				kamera.fieldOfView,
				sizeCameraNow,
				0.2f);
		*/
		
		if (Mathf.Abs(transform.position.z - zNow) < 0.2f) {
			Vector3 positionLerp = transform.position;
			positionLerp.z = zNow;
			transform.position = positionLerp;
		} else {
			Vector3 positionLerp = transform.position;
			float z = Mathf.Lerp(
				positionLerp.z,
				zNow,
				0.3f);
			positionLerp.z = z;
			transform.position = positionLerp;
		}
			
		Vector3 position = new Vector3(followingPosition.position.x, followingPosition.position.y, transform.position.z);
		position.y += 1f;
		transform.position = Vector3.SmoothDamp(transform.position, position, 
			ref velocity, 0.3f);
	}


	public void ZoomOut() {
		zNow = sizeCamera * 5f;
	}
	
	public void ZoomIn() {
		zNow = sizeCamera;
	}
}
