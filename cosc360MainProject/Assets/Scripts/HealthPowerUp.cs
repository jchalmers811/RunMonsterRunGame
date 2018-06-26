using UnityEngine;
using System.Collections;

public class HealthPowerUp : MonoBehaviour {

	public int amount = 50; 
	private PlayerHealth playerhealth;
	private GameObject player;

	// Use this for initialization
	void Start () {
	
		player = GameObject.FindGameObjectWithTag ("Player");

		playerhealth = player.GetComponent<PlayerHealth> ();

	}


	void OnTriggerEnter2D(Collider2D coll){

		if (coll.gameObject.tag == "Player") {
			playerhealth.TakeDamage (-1 * amount);
			Destroy (gameObject);
		} 

	} 
	
	// Update is called once per frame
	void Update () {
	
	}
}
