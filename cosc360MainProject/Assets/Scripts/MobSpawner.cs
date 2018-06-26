using UnityEngine;
using System.Collections;

public class MobSpawner : MonoBehaviour {

	public GameObject enemy; 
	private GameObject backAttacker;

	private GameObject player;
	private float y; 
	private float oldY; 
	private float timeSinceNoAdvancement; 
	private float camHeight; 
	private float camWidth;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		y = player.transform.position.y;
	
		// Get the width and height of the camera in pixels
		float screenH = Camera.main.pixelHeight;
		float screenW = Camera.main.pixelWidth;

		// Convert screen coordinates point (0,0) to world coordinates
		Vector3 leftBottom  = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));      
		// Convert screen coordinates point (0,H) to world coordinates
		Vector3 leftTop = Camera.main.ScreenToWorldPoint(new Vector3(0f, screenH, 0f));
		// Convert screen coordinates point (0,0) to world coordinates
		Vector3 rightBottom  = Camera.main.ScreenToWorldPoint(new Vector3(screenW, 0f, 0f));      
		// Convert screen coordinates point (0,H) to world coordinates
		Vector3 rightTop = Camera.main.ScreenToWorldPoint(new Vector3(screenW, screenH, 0f));

		// Get camera height so game knows when to load new blocks
		camHeight = leftTop.y - leftBottom.y; 
		camWidth = rightTop.y - leftTop.y;

		float spacing = camWidth / 10; 

		//for (int i = 0; i < 10; i++) { 
		//	backAttacker = Instantiate (enemy);  
		//	backAttacker.transform.position = leftBottom;
		//}


		InvokeRepeating ("CheckMobile", 5, 5);
	}
	
	// Update is called once per frame
	void CheckMobile () {
		if (player && y >= player.transform.position.y) {
			SpawnMob ();
		}

		if (player) {
			y = player.transform.position.y;
		}
	}	


	void SpawnMob () {
	
	}
}
