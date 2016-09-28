using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	//healthbar variables
	private int startingHealth = 3;
	private int currentHealth;
	public Slider healthSlider;

	void Start () {
		currentHealth = startingHealth;
	}
		
	//called when colliding with enemies
	public void takeDamage(int amount) {
		currentHealth -= amount;
		healthSlider.value = currentHealth;

		//if dead, save score and show game over scene
		if(currentHealth <= 0) {
			PlayerPrefs.Save ();
			Application.LoadLevel (3);
		}
	}

	//gain health from finish line
	public void gainHealth(int amount) {
		currentHealth += amount;
		healthSlider.value = currentHealth;
	}
}