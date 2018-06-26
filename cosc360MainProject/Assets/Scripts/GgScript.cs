using UnityEngine;
using System.Collections;

public class GgScript : MonoBehaviour {
	

	void Update(){

		if(Input.GetKey(KeyCode.R) && PlayerHealth.health <=0){
			StartLevel();
		} 
		
		if(Input.GetKey(KeyCode.E) && PlayerHealth.health <=0) {
		   ExitGame();
		}


		if(Input.GetKey(KeyCode.R) && TileLoaderv5.GameWon){
			StartLevel();
		} 

		if(Input.GetKey(KeyCode.E) && TileLoaderv5.GameWon) {
			ExitGame();
		}


	}

	public void StartLevel(){
		PlayerHealth.health = 100;
		PlayerStamina.curStamina = 100;
		GameMaster.playerScore = 0;
		EnemyController.meleBodyCount = 0;
		TileLoaderv5.GameWon = false; 
		Application.LoadLevel(Application.loadedLevel);

	}

	public void ExitGame(){
		PlayerHealth.health = 100;
		PlayerStamina.curStamina = 100;
		GameMaster.playerScore = 0;
		EnemyController.meleBodyCount = 0;
		TileLoaderv5.GameWon = false; 
		Application.LoadLevel("MainMenuJG");

	}
}
