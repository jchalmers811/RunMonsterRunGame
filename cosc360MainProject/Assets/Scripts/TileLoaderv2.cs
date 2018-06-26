using UnityEngine;
using System.Collections;

public class TileLoaderv2 : MonoBehaviour {
	//for mob spawn
	public GameObject enemy; 
	private GameObject backAttacker;
	private GameObject player;
	private float spacing;
	private float y; 
	private float oldY; 
	private float timeSinceNoAdvancement; 
	private float camHeight; 
	private float camWidth;



	// Arrary of perfab tiles 
	public Transform[] tiles; 

	private Transform tile;
	private Transform oldTile;

	//stores random number to pick tile 
	private int randomSample; 
	//needed to get block size 
	private Renderer floor;
	//for positioning of blocks 
	private Vector3 blockSize;
	//false if new block will need to be loaded soon, true if block was just loaded 
	private bool blockLoaded; 
	// positioning 
	private int blockDisplacement = 1; 

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

		camHeight = leftTop.y - leftBottom.y; 
		camWidth = rightTop.x - leftTop.x;

		// to spawn backAttackers evenly
		spacing = camWidth / 10;


		InvokeRepeating ("CheckMobile", 10, 3);


		//create random number in range of 0 to length of tiles array
		randomSample = Random.Range(0, tiles.Length); 

		//load random block 
		tile = Instantiate(tiles[randomSample]);
		tile.parent = transform;
		//get size of block 
		floor = tile.GetComponentInChildren<Renderer> ();

		blockSize = floor.bounds.size;
		print (blockSize);
		//render block at right position
		tile.position = new Vector3(0, blockSize.y/2 - camHeight/2 ,0);

	
	}

	// Update is called once per frame
	void Update () {
		Vector3 camPosition = Camera.main.gameObject.transform.position; 

		if (blockLoaded == false && camPosition.y >= (blockDisplacement * blockSize.y - camHeight)) { 
			blockLoaded = true;

			oldTile = tile; 

			randomSample = Random.Range(0, tiles.Length); 

			tile = Instantiate(tiles[randomSample]);
			tile.parent = transform;

			floor = tile.GetComponentInChildren<Renderer> ();
			blockSize = floor.bounds.size;
		

		
			tile.position = new Vector3 (0, blockDisplacement * blockSize.y + blockSize.y/2 - camHeight/2, 0);




		} 

		if (camPosition.y >= (blockDisplacement * blockSize.y + camHeight *3)) {
			blockDisplacement += 1; 
			blockLoaded = false; 
			Destroy ((oldTile as Transform).gameObject);
		}





	}


	void CheckMobile () {
		if (player && y >= player.transform.position.y) {
			SpawnMob ();
		}
		if (player) {
			y = player.transform.position.y;
			print ("y position: " + y);
			print ("MOVE UP");
		}
	}	


	void SpawnMob () {
		
		for (int i = 0; i < 9; i++) { 
			backAttacker = Instantiate (enemy);  
			backAttacker.transform.position = new Vector3(i * spacing - camWidth/2 + player.transform.position.x,
				player.transform.position.y - camHeight/2, -4);
		}

	}
}
