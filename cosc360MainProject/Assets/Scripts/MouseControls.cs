using UnityEngine;
using System.Collections;

public class MouseControls : MonoBehaviour {


	public float maxSpeed = 2.0f;
	public float turnSpeed = 1.5f;

	bool facingRight = true;
	bool facingTop = true;

	// Flag indicating whether the player is at the 
	// left edge of the screen
	bool stoneWall = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		///Player Punch////////////////
		/// /////////////////////////////
		if(Input.GetMouseButton(0)) {

			// Get player's attack component
			// and execute its Shoot() method
			PlayerAttack attack = GetComponent<PlayerAttack>();
			attack.Punch();
		} 
		/////////////////////////////////////
		/// /////////////////////////////////
	}




	// Update is called once per frame
	void FixedUpdate () {

		//	Player Movement 
		////////////////////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////////////////////
		// Player movement from input (it's a variable between -1 and 1) for
		// degree of left or right movement
		float moveVer = Input.GetAxis ("Vertical");
		float moveHor = Input.GetAxis ("Horizontal");


		if (!stoneWall) {
			if (Input.GetKey (KeyCode.W)) {
				transform.Translate(0,Time.deltaTime * maxSpeed * moveVer, 0);
			}

			if (Input.GetKey (KeyCode.S)) {
				transform.Translate(0,Time.deltaTime * (maxSpeed/3) * moveVer, 0);
			}



			Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		}
	}




}