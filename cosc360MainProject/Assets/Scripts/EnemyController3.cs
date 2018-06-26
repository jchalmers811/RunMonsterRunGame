using UnityEngine;
using System.Collections;

public class EnemyController3 : MonoBehaviour {

	Animator animate;
	Collider2D collider;
	public static int throwerBodyCount = 0;
	//PlayerFollow2 follow;
	//PlayerFollow2 follow2;

	// Use this for initialization
	void Start () {

		animate = GetComponent<Animator>();

		collider = GetComponent<Collider2D>();

		//follow = GetComponent<PlayerFollow2>();
		//follow2 = GetComponent<PlayerFollow2>();

	}

	// Update is called once per frame
	void Update () {

	}

	// On collision with a trigger collider...
	void OnTriggerEnter2D(Collider2D other) {
		// If the other object is tagged as "PlayerAttack"...
		if (other.gameObject.tag == "PlayerAttack") {
			Debug.Log("HIT3!!");
			//for score
			GameMaster.playerScore +=10;
			//////////////////////////////////
			//keep body count
			throwerBodyCount +=1;
			print (throwerBodyCount);
			////////////Animation death start/////////////
			animate.SetBool ("Death", true);
			collider.enabled = false;
			StartCoroutine (waitDeath());
			/////////////////////////////////


		}
	}

	//////////////////////////
	IEnumerator waitDeath ()
	{
		yield return new WaitForSeconds (0.8f);
		Destroy (gameObject);
	}
}
