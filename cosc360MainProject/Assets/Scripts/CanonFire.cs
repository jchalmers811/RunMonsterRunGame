using UnityEngine;
using System.Collections;

public class CanonFire : MonoBehaviour {
	public float speed = 5f;
	public float damage = 5f;
	public Transform target;
	public Vector2 temp;
	//Angle to target;
	public Vector3 vectorToTarget;
	private Rigidbody2D t;
	public PlayerHealth playerhealth;
	private GameObject player;
	private CircleCollider2D x;

	//Animator animate;//

	// Variable storing projectile object
	// prefab
	public Transform shotPrefab;

	// Probability of auto-shoot (0 if
	// no autoshoot)
	public float autoShootProbability;

	// Cooldown time for firing
	public float fireCooldownTime;

	// How much time is left until able to fire again 
	float fireCooldownTimeLeft = 0;


	// Use this for initialization
	void Start () {
		//get player position
		//target = GameObject.FindGameObjectWithTag ("Player").transform;

		player = GameObject.FindGameObjectWithTag ("Player");

		playerhealth = player.GetComponent<PlayerHealth> ();

		//animate = GetComponent<Animator>();//

	}

	// Update is called once per frame
	void Update () {

		//2d turning 
		/*
		 * if (player) {
			vectorToTarget = target.position - transform.position;
			Quaternion rotation = Quaternion.LookRotation
			(target.transform.position - transform.position, transform.TransformDirection (Vector3.forward));
			float rot = Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler (0, 0, rot - 90); 

			//update where to throw the bullet * 4 ahead of the player - not yet sure how this will work
			temp = new Vector2 (target.transform.position.x, target.transform.position.y * 4);

		} */
		// If still some time left until can fire again
		// reduce the time by the time since last
		// frame 
		if (fireCooldownTimeLeft > 0) {
			fireCooldownTimeLeft -= Time.fixedDeltaTime;
		}

		// If auto-shoot probability is more than zero...
		if(autoShootProbability > 0 && player) {
			// Generate number a random number between 0 and 1
			float randomSample = Random.Range(0f, 1f);
			// If that random number is less than the 
			// probability of shooting, then try to shoot
			if(randomSample < autoShootProbability) {

				Shoot();   
			}
		}
	}

	// Method for firing a projectile
	public void Shoot() {

		//////////////////////////////////
		////////////Animation throw start/////////////
		//animate.SetBool ("Throw", true);//
		/////////////////////////////////


		// Shoot only if the fire cooldown period
		// has expired
		if(fireCooldownTimeLeft <= 0) {
			// Create a projectile object from 
			// the shot prefab

			Transform shot = Instantiate(shotPrefab);
			// Set the position of the projectile object
			// to the position of the firing game object
			shot.position = transform.position;
			shot.transform.Translate(new Vector3(transform.position.x - 30,0,0));	
			//shoot
			t = shot.GetComponent<Rigidbody2D>();
			t.AddForce (transform.up * speed*60);

			//x = shot.GetComponent<CircleCollider2D>();


			// Set time left until next shot
			// to the cooldown time

			fireCooldownTimeLeft = fireCooldownTime;   
		}
	}
	/*
	void OnTriggerEnter2D(Collider2D coll){

		if (coll.gameObject.tag == "Player") {
			print ("BBBBBBBB");
			playerhealth.TakeDamage (damage);
		}
	}	
	*/

	////// Animationstop /// 
	/*
	public void StopAnimationThrow() {
		animate.SetBool("Throw", false);
	}*/
}