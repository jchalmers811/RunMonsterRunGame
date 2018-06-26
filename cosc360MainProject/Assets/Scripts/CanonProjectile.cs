using UnityEngine;
using System.Collections;

public class CanonProjectile : MonoBehaviour {

	private PlayerHealth playerhealth;
	private GameObject player;
	private GameObject mc;
	private Renderer rend;

	public float speed;


	void Start(){

		player = GameObject.FindGameObjectWithTag ("Player");

		if (player) {
			playerhealth = player.GetComponent<PlayerHealth> ();
		}


	}


	void OnTriggerEnter2D(Collider2D coll){

		if (coll.gameObject.tag == "Player") {
			playerhealth.TakeDamage (30);
			Destroy (gameObject);
		} else if (coll.gameObject.tag == "Thrower") {

		} else if(coll) {
			Destroy (gameObject);
		}

	} 

	void OnBecameInvisible(){
		Destroy (gameObject);

	}


	/*

	// Flag identifyng whether the projectile
	// is sent by enemy or the player
	public bool enemyProjectile;

	void Start () {
		playerPos = GameObject.FindGameObjectWithTag ("Player").transform.position;
		villagerPos = GameObject.FindGameObjectWithTag ("VillageThrower").transform.position;
	} */

	// Update is called once per frame
	void Update () {
		// The projectile travels up (in the direction of positive y axis), but
		// the movement is multiplies by speed (so negative speed will get 
		// move the projectile down)
		//transform.Translate(playerPos.transform.position.x, playerPos.transform.position.y*4, playerPos.transform.position.z  * speed * Time.deltaTime);



		transform.Translate (Vector3.left * speed * Time.deltaTime);

		//update where to throw the bullet * 4 ahead of the player - not yet sure how this will work
		//temp = new Vector2 (target.transform.position.x, target.transform.position.y*4);

	}


}
