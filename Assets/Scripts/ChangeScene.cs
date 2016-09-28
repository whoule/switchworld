using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	//used for button onClick method to change scenes

	public void loadMenu() {
		Application.LoadLevel (0);
	}

	public void loadInstructions() {
		Application.LoadLevel (1);
	}

	public void loadGame() {
		Application.LoadLevel (2);
	}
}
