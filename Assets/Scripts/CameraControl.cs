using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	//Variables
	public float camSpeed = 0.02f;
	private float camBoundaryRight = 38.65f;
	private float camBoundaryLeft = -0.96f;

	//put camera at left boundary
	void Start () {
		this.transform.position = new Vector3 (camBoundaryLeft, 0f, -10f);
	}

	void Update () {
		//constantly move the camera by camSpeed amount
		this.transform.position = new Vector3 (this.transform.position.x + camSpeed, 0f, -10f);

		//sets camera boundary to size of sprites
		if (this.transform.position.x > camBoundaryRight) {
			this.transform.position = new Vector3 (camBoundaryRight, 0f, -10f);
		} else if (this.transform.position.x < camBoundaryLeft) {
			this.transform.position = new Vector3 (camBoundaryLeft, 0f, -10f);
		}
	}

	//resets camera position
	public void resetSpawn() {
		this.transform.position = new Vector3 (camBoundaryLeft, 0f, -10f);
	}
}
