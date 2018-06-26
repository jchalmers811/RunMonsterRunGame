using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	// An array with the sprites used for animation
	public Sprite[] animSprites;

	// Controls how fast to change the sprites when
	// animation is running
	public float framesPerSecond;



	Animator animate;

	SpriteRenderer animRenderer;

	PlayerAttack attack;


	// Time passed since the start of animatin
	private float timeAtAnimStart;

	private float animationWaitTime = 0.5f;

	// Indicates whether animation is running or not
	private bool animRunning = false;

	// Indicates whether animation is punching or not
	private bool animPunching = false;



	// Speed of the movement
	public float speed = 4f;

	// Direction of the movement
	private float movementDir;

	float userInput = 0;

	// Use this for initialization
	void Start () {


		// Get a reference to game object renderer and
		// cast it to a Sprite Rendere
		/////animRenderer = GetComponent<Renderer>() as SpriteRenderer;
		/// 
		attack = GetComponent<PlayerAttack> ();

		animate = GetComponent<Animator>();
		
		//animate.enabled = false;

	}

	// Before rendering next frame...
	void Update () {

		/*	if(Input.GetKeyDown ("space")) {

			Debug.Log (attack.punchAllowed);

			if (attack.punchAllowed) {
				//animRunning = false;

				//animate.SetTrigger("Punch");
				Debug.Log ("animationhere");
				//animate.enabled = true;

				//StartCoroutine(StopPunch());
			} */
		


		//animate.enabled = false;

		if (Input.GetKeyDown (KeyCode.W)) {
			// Animation will start playing
			animRunning = true;
			userInput = 1;
		} else if (Input.GetKeyUp (KeyCode.W)) {
			animRunning = false;
			userInput = 0;
		}
	}


		////////// ANIMATION RUNNING /////////////
		/*if (animRunning) {
		// Animation is running, so we need to 
		// figure out what frame to use at this point
		// in time

		// Compute number of seconds since animation started playing
		float timeSinceAnimStart = Time.timeSinceLevelLoad - timeAtAnimStart;

		// Compute the index of the next frame    
		int frameIndex = (int)(timeSinceAnimStart * framesPerSecond);


		if (frameIndex < 6) {
			// Let the renderer know which sprite to
			// use next      
			animRenderer.sprite = animSprites [frameIndex];

		} else {
			// Animation finished, set the render
			// with the first sprite and stop the 
			// animation
			animRenderer.sprite = animSprites [0];
			animRunning = false;
		}  
	} 

	////////// ANIMATION PUNCHING /////////////
	if (animPunching) {

		// Animation is punching, so we need to 
		// figure out what frame to use at this point
		// in timeanimationWaitTime;

		/*	// Compute number of seconds since animation started playing
		float timeSinceAnimStart = Time.timeSinceLevelLoad - timeAtAnimStart;

		// Compute the index of the next frame    
		int frameIndex = (int)(timeSinceAnimStart * framesPerSecond + 5);


		if (frameIndex > 5 && frameIndex < 12) {
			// Let the renderer know which sprite to
			// use next      
			animRenderer.sprite = animSprites [frameIndex];

		} else {
			// Animation finished, set the render
			// with the first sprite and stop the 
			// animation
			animRenderer.sprite = animSprites [0];
			animPunching = false;
		}   
		animate.SetTrigger("Punch");
		//animate.enabled = true;
		animRunning = false;
		StartCoroutine(StopPunch());
		*/ 



	/////////////////////
	/// Method for how long player punches for...
	/// 
	/*IEnumerator StopPunch () {

	yield return new WaitForSeconds(animationWaitTime);
	//	animate.enabled = false;	
	animPunching = false;

	animRunning = true;

	animate.SetBool("Punch", false);
	Debug.Log ("punch false");

}*/
//////////////////////////

	// At fixed time intervals...
	void FixedUpdate () {




		if (!animRunning) {
			// The animation is triggered by user input

			//	float userInput = Input.GetAxis ("Vertical");
			if (userInput != 0f) {
				// User pressed the move left or right button

				// Animation will start playing
				animRunning = true;

				animate.SetTrigger("Run");

				// Record time at animation start
				timeAtAnimStart = Time.timeSinceLevelLoad;

				// Get the direction of the movement from the sign
				// of the axis input (-ve is left, +ve is right)
				movementDir = Mathf.Sign (userInput);
			} else {
				animRunning = false;
			} 

		}

		/* attack = GetComponent<PlayerAttack> ();


		if (attack.punchCooldownTimeLeft < 0.05f) {

			if (!animPunching) {
				// The animation is triggered by user input
				if (Input.GetButton ("Jump")) {
					// Animation will start playing
					animPunching = true;
				}
			}
		} */
	}
		
}




