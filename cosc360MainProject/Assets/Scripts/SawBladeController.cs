using UnityEngine;
using System.Collections;

public class SawBladeController : MonoBehaviour {

	private GameObject player;
	private PlayerHealth playerHealth;
	public float SawDamage = 40;

	Collider2D collider;

	// Use this for initialization
	void Start () {
		
		player = GameObject.FindGameObjectWithTag ("Player");

		playerHealth = player.GetComponent<PlayerHealth> ();

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

			playerHealth.TakeDamage (SawDamage);

		} 

	} 
}
