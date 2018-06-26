using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	Animator animate;
	Collider2D collider;
	PlayerFollow follow;

	public static int meleBodyCount = 0;
	//PlayerFollow2 follow2;

	private AudioSource[] allAudios;
	// Use this for initialization
	void Start () {

		animate = GetComponent<Animator>();

		collider = GetComponent<Collider2D>();

		follow = GetComponent<PlayerFollow>();
		//follow2 = GetComponent<PlayerFollow2>();

		if (Camera.main.gameObject.GetComponent<AudioSource>() != null) {
			allAudios = Camera.main.gameObject.GetComponents<AudioSource> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// On collision with a trigger collider...
	void OnTriggerEnter2D(Collider2D other) {
		// If the other object is tagged as "PlayerAttack"...
		if (other.gameObject.tag == "PlayerAttack") {
			Debug.Log("HIT!!");
			//code for keeping score
			GameMaster.playerScore +=10;

			if (allAudios.Length >= 7) {
				allAudios [Random.Range (1, 4)].Play ();  
			}
			//keeping body count record
			meleBodyCount += 1;
			//print (meleBodyCount);

			//////////////////////////////////
			////////////Animation death start/////////////
			animate.SetBool ("Death", true);
			collider.enabled = false;
			follow.enabled = false;
			//follow2.enabled = false;
			StartCoroutine (waitDeath());
			/////////////////////////////////
			/// 
			/// 
			}

		/*	if (other.gameObject.tag == "BearTrap") {
				Debug.Log("HIT!!");
				//////////////////////////////////
				////////////Animation death start/////////////
				animate.SetBool ("Death", true);
				collider.enabled = false;
				follow.enabled = false;
				//follow2.enabled = false;
				StartCoroutine (waitDeath());
				/////////////////////////////////

			
		}*/
	}

	//////////////////////////
	IEnumerator waitDeath () {
		yield return new WaitForSeconds(0.8f);
		Destroy(gameObject);
	}
}
