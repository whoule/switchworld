using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIControl : MonoBehaviour {

	//score text object
	public Text scoreText;

	//set the score
	void Start () {
		scoreText.text = "Score: " + PlayerPrefs.GetInt ("Score");
	}
		
	//update the score when playerprefs score changes
	void Update () {
		if (PlayerPrefs.HasKey ("Score")) {
			scoreText.text = "Score: " + PlayerPrefs.GetInt ("Score");
		}
	}
}
