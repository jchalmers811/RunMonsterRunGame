using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	
	public float maxSpeed = 2.0f;
	public float turnSpeed = 1.5f;


	bool facingRight = true;
	bool facingTop = true;


	PlayerAttack attack;

	Animator animate;

	// Flag indicating whether the player is at the 
	// left edge of the screen
	bool stoneWall = false;
	
	// Use this for initialization
	void Start () {

		attack = GetComponent<PlayerAttack>();

		animate = GetComponent<Animator>();

	}

	
	// Update is called once per frame
	void Update () {


		// Player movement from input (it's a variable between -1 and 1) for
		// degree of left or right movement
		float moveVer = Input.GetAxis ("Vertical");
		float moveHor = Input.GetAxis ("Horizontal");


		//Player bouncing of walls//
		///////////////////////////
		if (stoneWall) {
			if (moveHor < 0) {
				transform.Translate(0,0, 0);
				stoneWall = false;
			}
			if (moveHor > 0) {
				transform.Translate(0,0, 0);
				stoneWall = false;
			}
			if (moveVer < 0) {
				transform.Translate(0,0, 0);
				stoneWall = false;
			}
			if (moveVer > 0) {
				transform.Translate(0, 0, 0);
				stoneWall = false;
			}
		}



		///Player Punch////////////////
		/// /////////////////////////////
		if (Input.GetKeyDown ("space")) {

			if (!animate.GetBool ("Charge")) {

				attack.Punch ();
			}
		}

		///Player Charge////////////////
		/// /////////////////////////////
		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift))  {

			//if (attack.chargeAllowed) {

				attack.Charge ();
				//animate.SetBool ("Charge", true);

			}
		}
	
	
	
	
	
	// Update is called once per frame
	void FixedUpdate () {
		
		//	Player Movement 
		////////////////////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////////////////////
		float moveVer = Input.GetAxis ("Vertical");
		float moveHor = Input.GetAxis ("Horizontal");
				
		if (!stoneWall) {


		 if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow) ) {

				if (!animate.GetBool ("Charge")) {

					transform.Translate (0, Time.deltaTime * maxSpeed * moveVer, 0);

					///Animation settings////////////////
	
					if (!animate.GetBool ("Punch")) {	
						
						animate.SetBool ("Run", true);
					}
				} 
			} else if (Input.GetKeyUp (KeyCode.W) && Input.GetKeyUp (KeyCode.UpArrow) ) {

				///Animation settings////////////////
				animate.SetBool ("Run", false);

			}  


			if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow) ) {

				if (!animate.GetBool ("Charge")) {
					
					transform.Translate (0, Time.deltaTime * (maxSpeed / 3) * moveVer, 0);

					///Animation settings////////////////
					animate.SetBool ("Run", true);
				}

			}

			if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) { 
				transform.Rotate (Vector3.forward * turnSpeed);
			}

			if(Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
				transform.Rotate (-Vector3.forward * turnSpeed);
			}
					
		}
	}
	////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////

	// On collision with a trigger collider...
	void OnTriggerEnter2D(Collider2D other) {
		// Check the tag of the object the player
		// has collided with
		if(other.tag == "StoneWall") {
			// If collided with the wall, set
			// the wall flag to true
			stoneWall = true;
		} 
			
	}    
	
	
	
	// When no longer colliding with an object...
	void OnTriggerExit2D(Collider2D other) {
		// Check the tag of the object the player
		// has ceased to collide with
		if(other.tag == "StoneWall") {
			// If collided with the left wall, set
			// the left wall flag to true
			stoneWall = false;
		} 
	}


	public void StopAnimationRun() {
		animate.SetBool("Run", false);
	}

	////// Animationstop /// 
	public void StopAnimationHurt() {
		animate.SetBool("Hurt", false);
	}

}

