using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {

	//public PlayerHealth playerHealth;       // Reference to the player's health.
	public float restartDelay = 5f; 		// Time to wait before restarting the level
	public PlayerHealth playerHealth;

	AudioSource audio;
	bool onOff =false;

	
	
	Animator anim;                          // Reference to the animator component.
	float restartTimer;                     // Timer to count up to restarting the level
	
	
	void Awake ()
	{
		// Set up the reference.
		anim = GetComponent <Animator> ();




	}
	
	
	void Update ()
	{
		// If the player has run out of health...
		if(PlayerHealth.health <= 0)
		{
			if (!onOff) {
				audio = GetComponent<AudioSource> ();
				audio.Play ();
				//audio = null;
				onOff = true;
			}


			Destroy (GameObject.FindGameObjectWithTag ("Player"));
			// ... tell the animator the game is over.
			anim.SetTrigger ("GameOver");
			//Time.timeScale = 0;


			//PlayerHealth.health = 100;
			/*
			// .. increment a timer to count up to restarting.
			restartTimer += Time.deltaTime;
			
			// .. if it reaches the restart delay...
			if(restartTimer >= restartDelay)
			{
				// .. then reload the currently loaded level.
				Application.LoadLevel(Application.loadedLevel);
				PlayerHealth.health = 100;
			}
			*/
		}
			

		if (TileLoaderv5.GameWon == true) {
			
			Destroy (GameObject.FindGameObjectWithTag ("Player"));
			anim.SetTrigger ("GameWon");
		}

		//to activate congratulations script
		//anim.SetTrigger ("GameWon");
	}

}
