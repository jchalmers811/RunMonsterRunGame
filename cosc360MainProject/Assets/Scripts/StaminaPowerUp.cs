using UnityEngine;
using System.Collections;

public class StaminaPowerUp : MonoBehaviour {

	public int amount = 50; 
	private PlayerStamina playerStamina;
	private GameObject player;

	// Use this for initialization
	void Start () {
	
		player = GameObject.FindGameObjectWithTag ("Player");

		playerStamina = player.GetComponent<PlayerStamina> ();

	}


	void OnTriggerEnter2D(Collider2D coll){

		if (coll.gameObject.tag == "Player") {
			playerStamina.StaminaPowerUp(-1 * amount);
			Destroy (gameObject);
		} 

	} 
	
	// Update is called once per frame
	void Update () {
	
	}
}
