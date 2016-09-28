using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

	//sets final score variable on game over screen
	public Text finalScore;

	void Start () {
		finalScore.text = ("Final Score: " + PlayerPrefs.GetInt("Score"));
	}
}
