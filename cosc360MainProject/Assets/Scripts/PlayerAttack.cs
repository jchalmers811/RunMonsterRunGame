using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	// intended child prefab variable
	GameObject attackObject;

	PlayerController controller;
	PlayerStamina stamina;
	Animator animate;

	//jg adding sound
	AudioClip ac;
	AudioSource[] audio;

	// Cooldown time for punching
	public float punchCooldownTime = 1.0f;
	// punch duration 
	public float punchLastingTime = 0.5f;

	// Cooldown time for charging
	public float chargeCooldownTime = 5.0f;
	// charge duration 
	public float chargeLastingTime = 4.0f;
	

	public float punchStamDrain = 10f;
	public float chargeStamDrain = 50f;

	public bool punchAllowed;
	public bool chargeAllowed;

	private float curPlayerSpeed;

	void Start() {

		controller = GetComponent<PlayerController>();
		stamina = GetComponent<PlayerStamina>();
		animate = GetComponent<Animator>();

		audio = GetComponents<AudioSource> ();

		// finding child prefab
		attackObject = GameObject.Find ("PlayerAttack");
		attackObject.SetActive (false);
		
	}


	// Per every frame...
	void Update () {

		if (animate.GetBool ("Charge")) {
			StraightRun ();
		}
	}



	// Method for Punching
	public void Punch() {
		// Shoot only if the fire cooldown period
		// has expired

		if (PlayerStamina.curStamina > punchStamDrain) {

			if (punchAllowed) {

				animate.SetBool ("Charge", false);
				animate.SetBool ("Punch", true);
				animate.SetBool ("Run", false);

				stamina.MinusStamina (punchStamDrain);

				punchAllowed = false;

				audio[1].Play ();


				attackObject.SetActive (true);
	
				StartCoroutine (StopPunch ());

				// Set time left until next shot
				// to the cooldown time

				////punchCooldownTimeLeft = punchCooldownTime;  
				
			}
		}
	}

	// Method for Charging
	public void Charge() {
		// Shoot only if the fire cooldown period
		// has expired

		if (PlayerStamina.curStamina > chargeStamDrain) {

			if (chargeAllowed) {
				audio[2].Play ();

				animate.SetBool ("Charge", true);
				animate.SetBool ("Run", false);
				animate.SetBool ("Punch", false);


				stamina.MinusStamina (chargeStamDrain);

				chargeAllowed = false;


				curPlayerSpeed = controller.maxSpeed;
				//controller.maxSpeed = (controller.maxSpeed * 2);

				attackObject.SetActive (true);

				StartCoroutine (StopCharge ());

				// Set time left until next shot
				// to the cooldown time

				////punchCooldownTimeLeft = punchCooldownTime;  

			}
		}
	}


	/////////////////////
	/// Method for how long player punches for...
	/// 
		IEnumerator StopPunch () {
		yield return new WaitForSeconds(punchLastingTime);
		attackObject.SetActive (false);
		StartCoroutine(WaitPunch ());
		}
		
		IEnumerator WaitPunch () {
		yield return new WaitForSeconds(punchCooldownTime);
		animate.SetBool ("Punch", false);
		punchAllowed = true;
	}
	//////////////////////////
	/////////////////////////////


	/////////////////////
	/// Method for how long player punches for...
	/// 
	IEnumerator StopCharge () {
		yield return new WaitForSeconds(chargeLastingTime);
		StopAnimationCharge ();
		controller.maxSpeed = curPlayerSpeed;
		chargeAllowed = false;
		attackObject.SetActive (false);
		StartCoroutine(WaitCharge ());
	}

	//////////////////////////
	IEnumerator WaitCharge () {
		yield return new WaitForSeconds(chargeCooldownTime);
		chargeAllowed = true;
	}


	/////////////////////////////
	/// Propelling player in straight line
	void StraightRun() {

		transform.Translate (0, Time.deltaTime * controller.maxSpeed * 2, 0);
	}



	public void StopAnimationPunch() {
		animate.SetBool("Punch", false);
	}

	public void StopAnimationCharge() {
		animate.SetBool("Charge", false);
	}
}
