using UnityEngine;
using System.Collections;

public class Comic2Game : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(comicEnd ());
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.anyKey) {
			// Start the new game
			// Load the first level
			Application.LoadLevel("TileLoaderv5Test");     
		}

	}


	//////////////////////////
	IEnumerator comicEnd () {
		yield return new WaitForSeconds(28.35f);
		// Start the new game
		// Load the first level
		Application.LoadLevel("TileLoaderv5Test");   
	}
}
