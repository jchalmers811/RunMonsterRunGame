using UnityEngine;
using System.Collections;

public class DestructablesController : MonoBehaviour {

	Animator animate;
	Collider2D collider;
	private AudioSource[] allAudios;

	// Use this for initialization
	void Start () {

		animate = GetComponent<Animator>();

		collider = GetComponent<Collider2D>();

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
			//Debug.Log("HIT!!");

			if (allAudios.Length >= 7) {
				allAudios [Random.Range (4, 7)].Play ();
			}
			//////////////////////////////////
			////////////Animation death start/////////////
			animate.SetBool ("Death", true);
			collider.enabled = false;
			StartCoroutine (waitDeath());
			/////////////////////////////////


		}
	}

	//////////////////////////
	IEnumerator waitDeath () {
		yield return new WaitForSeconds(0.4f);
		Destroy(gameObject);
	}
}
