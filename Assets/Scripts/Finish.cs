using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour {

	//check for finish line
	private bool finished = false;

	//background, player, playerHealth, camera, platform, coin, birds and enemy1 call to scripts
	ChangeBackground changeBG;
	PlayerControl player;
	PlayerHealth playerHealth;
	CameraControl camera;
	SpawnPlatforms platforms;
	BirdAI birds;
	Enemy1AI enemy1;

	//instantiations for script references
	void Start() {
		changeBG = GameObject.FindGameObjectWithTag ("Background").GetComponent<ChangeBackground> ();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
		playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
		camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControl>();
		platforms = GameObject.FindGameObjectWithTag("Ground").GetComponent<SpawnPlatforms>();
		birds = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdAI>();
		enemy1 = GameObject.FindGameObjectWithTag("Enemy1").GetComponent<Enemy1AI>();
	}

	//when you touch the finish line
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			finished = true;
		}
	}

	//change backgrounds and reset player, add health, reset camera, birds and enemies
	void Update() {
		if(finished) {
			finished = false;
			changeBG.changeBG (changeBG.currentBG);
			player.resetSpawn ();
			playerHealth.gainHealth (1);
			camera.resetSpawn ();
			platforms.removeSpawn ();
			birds.removeSpawn ();
			enemy1.removeSpawn ();
		}
	}
}
