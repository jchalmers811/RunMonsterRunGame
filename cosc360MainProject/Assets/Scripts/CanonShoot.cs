using UnityEngine;
using System.Collections;

public class CanonShoot : MonoBehaviour {
	public float speed = 5f;
	public float damage = 5f;
	public Transform target;
	public Vector2 temp;
	public float fireOffSet = -2f;

	private Rigidbody2D t;
	private GameObject player;


	Animator animate;

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
		target = GameObject.FindGameObjectWithTag ("Player").transform;

		player = GameObject.FindGameObjectWithTag ("Player");

		animate = GetComponent<Animator>();

	}

	// Update is called once per frame
	void Update () {

		//2d turning 
		if (player) {
			if (player.transform.position.y >= transform.position.y - 15) { 
				Shoot();
			}
		}

		// If still some time left until can fire again
		// reduce the time by the time since last
		// frame 
		if (fireCooldownTimeLeft > 0) {
			fireCooldownTimeLeft -= Time.fixedDeltaTime;
		}

	}

	// Method for firing a projectile
	public void Shoot() {

		// Shoot only if the fire cooldown period
		// has expired
		if(fireCooldownTimeLeft <= 0) {
			// Create a projectile object from 
			// the shot prefab

			Transform shot = Instantiate(shotPrefab);
			// Set the position of the projectile object
			// to the position of the firing game objec
		

			shot.position = new Vector3(fireOffSet + transform.position.x, transform.position.y,transform.position.z);
			//shoot
			t = shot.GetComponent<Rigidbody2D>();
			t.AddForce (new Vector3(1,0,0) * speed*60);

			//x = shot.GetComponent<CircleCollider2D>();


			// Set time left until next shot
			// to the cooldown time

			fireCooldownTimeLeft = fireCooldownTime;   
		}
	}

}