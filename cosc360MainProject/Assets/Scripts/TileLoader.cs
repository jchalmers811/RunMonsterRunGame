using UnityEngine;
using System.Collections;

public class TileLoader : MonoBehaviour {
	
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
	private float camHeight;
	//false if new block will need to be loaded soon, true if block was just loaded 
	private bool blockLoaded; 
	// positioning 
	private int blockDisplacement = 1; 

	// Use this for initialization
	void Start () {
		// Get the width and height of the camera in pixels
		float screenH = Camera.main.pixelHeight;

		// Convert screen coordinates point (0,0) to world coordinates
		Vector3 leftBottom  = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));      
		// Convert screen coordinates point (0,H) to world coordinates
		Vector3 leftTop = Camera.main.ScreenToWorldPoint(new Vector3(0f, screenH, 0f));
		// Get camera height so game knows when to load new blocks
		camHeight = leftTop.y - leftBottom.y; 


		//create random number in range of 0 to length of tiles array
		randomSample = Random.Range(0, tiles.Length); 

		//load random block 
		tile = Instantiate(tiles[randomSample]);
		tile.parent = transform;
		//get size of block 
		floor = tile.GetComponentInChildren<Renderer> ();
		blockSize = floor.bounds.size;
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

		if (camPosition.y >= (blockDisplacement * blockSize.y + camHeight)) {
			blockDisplacement += 1; 
			blockLoaded = false; 
			Destroy ((oldTile as Transform).gameObject);
		}


	}
}
