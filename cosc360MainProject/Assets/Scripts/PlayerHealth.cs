using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public static float health = 100f;
	public bool alive = true;
	public bool invincible = false;
	public float invincibilityTime = 0.5f;
	private float invincibilityCooldown;

	SpriteRenderer rend;

	void Start () {

		///PLayer change to red when hit
		rend = GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		if (invincibilityCooldown > 0) {
			invincibilityCooldown -= Time.fixedDeltaTime;
		} else { 
			invincible = false;
		}
	}
			

	public void TakeDamage(float amount){

		if (!invincible) {
			
			///PLayer change to red when hit
			Color red = new Color (255, 0, 0, 255);
			rend.color = red;
			StartCoroutine (changeColorBack ());

			invincible = true;
			invincibilityCooldown = invincibilityTime; 

			health -= amount;
		
		} else if (health - amount > 100) {
			health = 100;
		} else if (0 - amount > 0) { 
			health -= amount;
		}




		if (health <= 0 && alive) {
			alive = false;
			//testing the update of stamina
			PlayerStamina.curStamina = 100;
			////
			GameMaster.GameOver();

		}
	}
	
	
	//////////////////////////
	IEnumerator changeColorBack () {
		yield return new WaitForSeconds(0.2f);
		Color white = new Color(255,255,255,255);
		rend.color = white;
	}



}
