using UnityEngine;
using System.Collections;

public class CoinCollection : MonoBehaviour {

	//when the player collides with this coin prefab, update the score
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			Destroy (gameObject);
			updateScore ();
		}
	}

	//save the score in playerprefs
	void updateScore() {
		PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt("Score") + 1);
		PlayerPrefs.Save ();
	}
}
