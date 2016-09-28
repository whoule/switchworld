using UnityEngine;
using System.Collections;

public class ChangeBackground : MonoBehaviour {

	//Sprites for changing the map
	public Sprite background1, background2, background3, background4;
	public Sprite ground1, ground2, ground3, ground4;
	private SpriteRenderer bgSpriteRenderer, gSpriteRenderer, topBarSpriteRenderer; 

	//arrays for changing map
	public Sprite[] backgrounds;
	private Sprite[] grounds;

	//currentBG number
	public int currentBG;

	//initializations
	void Start ()
	{
		//if the game just started, set it to the first map in the array
		if(currentBG == null) {
			currentBG = 0;
		}

		bgSpriteRenderer = GameObject.Find("Background").GetComponent<SpriteRenderer>();
		gSpriteRenderer = GameObject.Find("Ground").GetComponent<SpriteRenderer>();
		topBarSpriteRenderer = GameObject.Find("TopBar").GetComponent<SpriteRenderer>();
		backgrounds = new Sprite[] {background1, background2, background3, background4};
		grounds = new Sprite[] {ground1, ground2, ground3, ground4};
	}

	//changes background and walkway based on the number generated
	//makes sure that the currentBG isn't repeated
	public void changeBG (int currentBG)
	{
		int num = Random.Range (0, backgrounds.Length);

		if (num != currentBG) {
			bgSpriteRenderer.sprite = backgrounds [num];
			gSpriteRenderer.sprite = grounds [num];
			topBarSpriteRenderer.sprite = grounds [num];
			currentBG = num;
		} else {
			num = Random.Range (0, backgrounds.Length);
		}
	}
}