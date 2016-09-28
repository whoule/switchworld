using UnityEngine;
using System.Collections;

public class Enemy1AI : MonoBehaviour {

	//position variables
	private const float startingYpos = 7f;
	private const float minXpos = 0f;
	private const float maxXpos = 44f;

	//keep track of direction
	private float direction;

	//firstSpawn is used to determine if the enemy should change direction when hitting the ground
	//stops them from changing direction mid air
	private int firstSpawn = -1;
	private bool spawned = false;

	//speed variable
	private float speed = 1.5f;

	//manipulations of animator and physics
	private Animator anim;
	private Rigidbody2D rb2D;

	//called to use takeDamage method
	PlayerHealth playerHealth;

	void Awake() {
		rb2D = this.GetComponent<Rigidbody2D> ();
	}

	//initializations and invoke call to spawn enemy every 4 seconds
	void Start () {
		anim = this.GetComponent<Animator> ();
		playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth>();
		direction = anim.GetInteger ("Direction");
		Invoke ("Spawn", 4);
	}

	//checks what direction to walk in and walks either left or right while changing animation
	void Update () {
		if(direction == 0) {
			anim.SetInteger ("Direction", 0);
			rb2D.velocity = new Vector2 (-speed, rb2D.velocity.y);
		} else if (direction == 1) {
			anim.SetInteger ("Direction", 1);
			rb2D.velocity = new Vector2 (speed, rb2D.velocity.y);
		}
	}
		
	//destroy and add to score
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			Destroy (this.gameObject);
			PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt("Score") + 2);
		}
	}

	//take damage and kill enemy
	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			playerHealth.takeDamage (1);
			Destroy (this.gameObject);
		}

		//update first spawn after the object hits a platform or the ground
		firstSpawn++;

		//if you hit platform or boundary change walking direction (patrol)
		//also only changes direction after you hit a platform for the first time
		if((other.gameObject.CompareTag("Platform") || other.gameObject.CompareTag("Boundary") || other.gameObject.CompareTag("Enemy1")) && (firstSpawn > 0)) {
			if (direction == 0) {
				direction = 1;
			} else if(direction == 1) {
				direction = 0;
			}
		}
	}

	//spawn new enemy at a random range
	void Spawn() {
		float tempX = Random.Range (GameObject.FindGameObjectWithTag("Player").transform.position.x + 10, maxXpos);
		if(GameObject.FindGameObjectWithTag("Player").transform.position.x < maxXpos) {
			Instantiate (this.gameObject, new Vector3 (tempX, startingYpos, 0f), Quaternion.identity);
		}
	}

	//removes existing spawns and starts over
	public void removeSpawn(){
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy1");
		for(int i = 1; i < enemies.Length; i++) {
			Destroy (enemies[i]);
		}

		Start ();
	}
}
