using UnityEngine;
using System.Collections;

public class BirdAI : MonoBehaviour {

	//bird y and speed values
	private const float birdY = 1.8f;
	private const float birdStartX = 50f;
	private float birdSpeed = 0.3f;

	private bool collided = false;

	PlayerHealth playerHealth;

	//spawn a bird at the initial positon and then another every 3 seconds
	void Start () {
		this.transform.position = new Vector3(birdStartX, birdY);
		Invoke ("Spawn", 3);
		playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
	}

	//bird flight left
	void Update () {
		this.transform.position = new Vector3(this.transform.position.x - birdSpeed, birdY);
	}

	//spawn a new bird off screen
	void Spawn() {
		Instantiate (this.gameObject, new Vector3(birdStartX, birdY, 0f), Quaternion.identity);
	}

	//if hit, set collided to true and take damage
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player") && !collided) {
			collided = true;
			playerHealth.takeDamage (1);
		}
	}

	//reset collision so damage can be taken again
	void OnTriggerExit2D(Collider2D other) {
		collided = false;
	}

	//remove spawned birds and start over
	public void removeSpawn(){
		GameObject[] birds = GameObject.FindGameObjectsWithTag ("Bird");
		for(int i = 1; i < birds.Length; i++) {
			Destroy (birds[i]);
		}

		Start ();
	}
}
