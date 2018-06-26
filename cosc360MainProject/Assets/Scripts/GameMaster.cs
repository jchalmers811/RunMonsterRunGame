using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	//public static float playerHealth = 100f;
	public static float playerScore = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	}

	/*
	public static void TakeDamage(float amount){
		if (playerHealth <= 0) {
			GameOver ();
		} else {
			playerHealth -= amount;
		}
	}
*/

	public static void GameOver ()
	{
		GameObject playerObject = GameObject.FindWithTag ("Player");

		if(playerObject) BodyCountScript.getBodyCount ();

		Destroy (playerObject);

	

	}


}
