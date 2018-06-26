using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public Canvas exitMenu;
	public Button playText;
	public Button quitText;
	public Text btnText;


	// Use this for initialization
	void Start () {
	
		exitMenu = exitMenu.GetComponent<Canvas> ();
		playText = playText.GetComponent<Button> ();
		quitText = quitText.GetComponent<Button> ();
		btnText = btnText.GetComponent<Text> ();
		exitMenu.enabled = false;
	}

	void Update(){


		if (Input.GetKeyDown ("return") || Input.GetKeyDown ("space")) {

			btnText.text = "loading....";
		


			// Start the new game
			// Load the first level
			Application.LoadLevel("Dylans ComicStrip Intro");     
		}
	
		if (exitMenu.enabled) {

			if (Input.GetKey (KeyCode.Y)) {
				ExitGame ();
			}
		
			if (Input.GetKey (KeyCode.N)) {
				NoPress ();
			}
	
		}
	}
	
	public void QuitPress(){

		exitMenu.enabled = true;
		playText.enabled = false;
		quitText.enabled = false;

	}

	public void NoPress(){

		exitMenu.enabled = false;
		playText.enabled = true;
		quitText.enabled = true;
	}

	public void StartLevel(){
		
		exitMenu.enabled = false;
		playText.enabled = true;
		quitText.enabled = false;

		btnText.text = "loading....";
		PlayerHealth.health = 100;
		PlayerStamina.curStamina = 100;
		Application.LoadLevel("Dylans ComicStrip Intro");

	}

	public void ExitGame(){
		Application.Quit();

	}
}
