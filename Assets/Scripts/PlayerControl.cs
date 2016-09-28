using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	//Position Variables
	private float horizontal; 
	private const float startingXpos = -7f;
	private const float startingYpos = -3.363001f;

	//Speed Variables
	private float speed = 3f;

	//Jump Variables
	private float jumpForce = 300f;
	private float doubleJumpForce = 150f;
	private bool canDoubleJump = false;
	private bool grounded = false;
	public Transform groundCheck;

	//Other Variables
	private Rigidbody2D rb2D;
	private Animator anim;
	public GameObject player;
	PlayerHealth playerHealth;

	void Awake() {
		rb2D = this.GetComponent<Rigidbody2D> ();
		anim = this.GetComponent<Animator> ();
	}

	//set starting position and score
	void Start () {
		this.transform.position = new Vector3 (startingXpos, startingYpos, 0);
		playerHealth = this.GetComponent<PlayerHealth>();
		PlayerPrefs.DeleteAll ();
		PlayerPrefs.SetInt ("Score", 0);
	}

	//used for jump physics with groundcheck, with double jump
	void Update () {
		grounded = Physics2D.Linecast(player.transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		//jumping
		if (Input.GetButtonDown ("Jump")) {
			if (grounded) {
				rb2D.velocity = new Vector2 (rb2D.velocity.x, 0);
				rb2D.AddForce (new Vector2 (0f, jumpForce));
				canDoubleJump = true;
			} else {
				if (canDoubleJump) {
					canDoubleJump = false;
					rb2D.AddForce (new Vector2 (0f, doubleJumpForce));
				}
			}
		}
	}

	//lateral movements
	void FixedUpdate() {
		//animation based on position on axis
		horizontal = Input.GetAxis ("Horizontal");

		//right, left, and idle animations with speed calculations
		if (horizontal > 0) {
			anim.SetInteger ("Direction", 2);
			rb2D.velocity = new Vector2 (speed, rb2D.velocity.y);
		} else if (horizontal < 0) {
			anim.SetInteger ("Direction", 1);
			rb2D.velocity = new Vector2 (-speed, rb2D.velocity.y);
		} else {
			anim.SetInteger ("Direction", 0);
			rb2D.velocity = new Vector2 (0, rb2D.velocity.y);
		}
	}

	//reset spawn point
	public void resetSpawn() {
		this.transform.position = new Vector3 (startingXpos, startingYpos, 0);
	}
}
