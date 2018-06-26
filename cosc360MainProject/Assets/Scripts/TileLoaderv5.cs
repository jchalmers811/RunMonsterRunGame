using UnityEngine;
using System.Collections;

public class TileLoaderv5 : MonoBehaviour {
	//for mob spawn
	public GameObject[] enemy;

	public bool spawnBackAttackers = false;

	public static bool GameWon = false;
	public GameObject backAttacker;

	private GameObject player;
	private float spacing;
	private float y; 
	private float oldY; 
	private float timeSinceNoAdvancement; 
	private float camHeight; 
	private float camWidth;

	// Arrary of perfab tiles 
	public Transform Ftile;  
	public Transform[] Etiles; 
	public Transform[] Mtiles;
	public Transform[] Htiles;
	public Transform CheckPointtile;
	public Transform Ltile;

	private int Ecounter = 0; 
	private int Mcounter = 0;
	private int Hcounter = 0;

	private Transform tile;
	private Transform oldTile;

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




		//load random block 
		tile = Instantiate(Ftile);
		tile.parent = transform;
		//get size of block 
		floor = tile.GetComponentInChildren<Renderer> ();

		blockSize = floor.bounds.size;
		print (blockSize);
		//render block at right position
		tile.position = new Vector3(0, blockSize.y/2 - camHeight/2 ,0);

		ShuffleArray(Etiles); 
		ShuffleArray(Mtiles); 
		ShuffleArray(Htiles); 
	}

	// Update is called once per frame
	void Update () {
		Vector3 camPosition = Camera.main.gameObject.transform.position; 



		if (blockLoaded == false && camPosition.y >= (blockDisplacement * blockSize.y - camHeight)) { 
			blockLoaded = true;

			oldTile = tile; 

			if (blockDisplacement == 12) { 
				tile = Instantiate (Ltile);
			} else if (blockDisplacement % 4 == 1) {
				tile = Instantiate (Etiles [Ecounter]);
				Ecounter++; 
			} else if (blockDisplacement % 4 == 2) {
				tile = Instantiate (Mtiles [Mcounter]);
				Mcounter++; 
			} else if (blockDisplacement % 4 == 3) { 
				tile = Instantiate (Htiles [Hcounter]);
				Hcounter++; 
			} else {
				CancelInvoke(); 
				tile = Instantiate (CheckPointtile);
			}



			//tile = Instantiate(tile);


			//get floor size then laoder in tile 
			tile.parent = transform;
			floor = tile.GetComponentInChildren<Renderer> ();
			blockSize = floor.bounds.size;
			tile.position = new Vector3 (0, blockDisplacement * blockSize.y + blockSize.y/2 - camHeight/2, 0);

			if (blockDisplacement % 4 == 1 && spawnBackAttackers) {
				InvokeRepeating ("SpawnMob", 1, 3);
			}  
		} 

		if (camPosition.y >= (blockDisplacement * blockSize.y + camHeight *3)) {
			blockDisplacement += 1;


			if (blockDisplacement == 13) { 
				//Trigger Ending Here
				print ("End");
				print (GameWon);
				GameWon = true;
			
			}
			print (GameWon);
			blockLoaded = false; 
			Destroy ((oldTile as Transform).gameObject);
		}





	}

	//suffle tile array
	public static void ShuffleArray<T>(T[] arr) {
		for (int i = arr.Length - 1; i > 0; i--) {
			int r = Random.Range(0, i + 1);
			T tmp = arr[i];
			arr[i] = arr[r];
			arr[r] = tmp;
		}

	}


	void SpawnMob () {

		if (player && player.transform.position.x + camWidth >= blockSize.x / 2) {
			for (int i = 0; i < 9; i++) { 
				backAttacker = Instantiate (enemy [i % 3]);  
				backAttacker.transform.position = new Vector3 (i * spacing - camWidth + player.transform.position.x,
					player.transform.position.y - camHeight / 2, -4);
				backAttacker.transform.localScale += new Vector3 (0.3f, 0.3f, 0);  
			} 
		} else if (player && player.transform.position.x - camWidth <= -1 * blockSize.x / 2) {
			for (int i = 0; i < 9; i++) { 
				backAttacker = Instantiate (enemy [i % 3]);  
				backAttacker.transform.position = new Vector3 (i * spacing + player.transform.position.x,
					player.transform.position.y - camHeight / 2, -4);
				backAttacker.transform.localScale += new Vector3 (0.3f, 0.3f, 0);  
			} 
		} else if (player){ 
			for (int i = 0; i < 9; i++) { 
				backAttacker = Instantiate (enemy [i % 3]);  
				backAttacker.transform.position = new Vector3 (i * spacing - camWidth / 2 + player.transform.position.x,
					player.transform.position.y - camHeight / 2, -4);
				backAttacker.transform.localScale += new Vector3 (0.3f, 0.3f, 0);  
			} 

		}
	}
}