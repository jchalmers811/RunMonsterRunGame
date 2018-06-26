using UnityEngine;
using System.Collections;

public class BearTrapController : MonoBehaviour {

	private GameObject player;
	private PlayerHealth playerHealth;

	Animator animate;
	Collider2D collider;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");

		playerHealth = player.GetComponent<PlayerHealth> ();

		animate = GetComponent<Animator>();
	
		collider = GetComponent<Collider2D>();
	}

	
	// Update is called once per frame
	void Update () {

	}
		

	////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////

	// On collision with a trigger collider...
	void OnTriggerEnter2D(Collider2D other) {
		// Check the tag of the object the player
		// has collided with
		if(other.tag == "Player") {
	
			//////annimationstop
			animate.SetBool ("Attack", true);

			playerHealth.TakeDamage (30);

			this.GetComponent<CircleCollider2D>();
			collider.enabled = false;
		} 

	}    



	// When no longer colliding with an object...
	void OnTriggerExit2D(Collider2D other) {


	}
	

	void OnCollisionEnter2D(Collision2D other){

	}

	void OnCollisionExit2D(Collision2D other){

	}




	////// Animationstop /// 
	public void StopAnimationClose() {
		animate.SetBool("Close", true);
	}


}
