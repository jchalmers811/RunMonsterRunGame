using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public float basicAttack = 2f;
	public float hardAttack = 5f;
	public float critAttack = 8f;
	private GameObject player;
	private PlayerHealth playerHealth;

	AudioSource ac;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		//GameObject player = GameObject.FindWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();

		//get Audio for hit
		//ac = GetComponent<AudioSource>();

	

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//AI attack with 3 different types of hits on monster
	//a random chance of getting one of these will happen
	public void AIAttack(){

		float random = Random.Range(0, 10);


		if (random <= 4) {
			playerHealth.TakeDamage (basicAttack);
			//ac.Play ();

		} else if (random > 4 && random <= 8) {
			playerHealth.TakeDamage (hardAttack);
			//ac.Play ();

		} else if (random > 8 && random <= 10) {
			playerHealth.TakeDamage (critAttack); 
			//ac.Play ();
		}

	
	}
}
