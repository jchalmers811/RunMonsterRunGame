using UnityEngine;
using System.Collections;

public class PlayerStamina : MonoBehaviour {

	public float maxStamina = 1000;

	public static float curStamina = 100;
	//public static float displayStamina = 100;

	public float staminaRegenTime = 1.0f;



	public void MinusStamina(float amount){

		curStamina -= amount;
		//displayStamina -= amount;
	}


	/* void AdjustUp(int adj) {

		float tempCurStamina = curStamina += adj;

		if(tempCurStamina > maxStamina) {
			curStamina = maxStamina;
		} else {
			curStamina = tempCurStamina;
		}
	} */

	void AdjustStamina() {


		if (curStamina < maxStamina) {

			curStamina = Mathf.Min (curStamina + staminaRegenTime * Time.deltaTime, maxStamina);

		} 
	}


	// Update is called once per frame
	void Update () {

	/* if(We hit a stamina booster) {
		AdjustUp (amount);
	}  */


		AdjustStamina ();
	}

	public void StaminaPowerUp(float amount){

		if (curStamina - amount > 100) {
			curStamina = 100;
		} else {
			curStamina -= amount;
		}


}
}
