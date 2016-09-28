using UnityEngine;
using System.Collections;

public class BehindCamera : MonoBehaviour {

	//position and call to playerHealth for takeDamage
	private float startX = -11.8f;
	PlayerHealth playerHealth;

	//set position and get health script
	void Start() {
		playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth>();
		this.transform.position = new Vector3 (startX, 0f, 0f);
	}

	//kill player if you hit the boundary behind camera
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			playerHealth.takeDamage (3);
		}
	}
}
