using UnityEngine;
using System.Collections;

public class SpawnPlatforms : MonoBehaviour {

	//objects for all platform sizes and coin
	public GameObject pSmall, pBig, pSmallLong, pBigLong;
	public GameObject coin;

	//coin map boundaries
	private const float coinMaxY = 1f;
	private const float coinMinY = -0.5f;
	private const float coinMaxX = 44f;
	private const float coinMinX = -5f;

	//array of platforms and the amount spawned with distance between each spawn
	private GameObject[] platformArray;
	private const float distanceFromEachOther = 9;
	private const int spawnAmount = 5;

	private GameObject player;

	//instantiations and spawn
	void Start () {
		platformArray = new GameObject[]{pSmall, pBig, pSmallLong, pBigLong};
		player = GameObject.Find ("Player");
		Spawn ();
	}

	//spawns 5 platforms 9 units apart from each other, random platform sizes
	//also spawns between 5-10 coins within the boundaries with random locations
	void Spawn() {
		//initial spawn based on player position
		float tempDistance = player.transform.position.x + 5;

		//platform spawn
		for (int i = 0; i <= spawnAmount; i++) {
			int temp = Random.Range (0, platformArray.Length);
			Instantiate (platformArray[temp], new Vector3(tempDistance, platformArray[temp].transform.position.y, 0f), Quaternion.identity);
			tempDistance += distanceFromEachOther;
		}

		//coin spawn
		int temp2 = Random.Range(5, 10);
		for(int j = 0; j <= temp2; j++) {
			float randX = Random.Range (coinMinX, coinMaxX);
			float randY = Random.Range (coinMinY, coinMaxY);
			Instantiate (coin, new Vector3(randX, randY, 0), Quaternion.identity);
		}
	}

	//removes spawned platforms
	public void removeSpawn(){
		GameObject[] platforms = GameObject.FindGameObjectsWithTag ("Platform");
		for(int i = 0; i < platforms.Length; i++) {
			Destroy (platforms[i]);
		}

		Spawn ();
	}
}
