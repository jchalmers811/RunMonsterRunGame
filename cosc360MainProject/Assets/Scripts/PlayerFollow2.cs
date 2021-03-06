﻿using UnityEngine;
using System.Collections;

public class PlayerFollow2 : MonoBehaviour {

	public float moveSpeed;
	public float turnSpeed = 5f; 
	public Transform target;
	public Transform enemy;
	public Vector3 vectorToTarget;
	//public PlayerHealth playerHealth;
	public EnemyAttack enemyAttack;
	public GameObject Enemy;
	//public Vector3 vectorP;
	//public Vector3 vectorE;
	//public float angle;

	Animator animate;

	// Use this for initialization
	void Start () {
		//get the "player" as target - transform gives the info we need for this
		target = GameObject.FindGameObjectWithTag ("Player").transform;

		//enemy = GameObject.FindGameObjectWithTag ("Enemy").transform;

		moveSpeed = Random.Range (3, 9);
		//test = transform.GetComponent<PlayerHealth>();
		//get the 'player object' by putting that objects transform information
		//playerHealth = target.gameObject.GetComponent<PlayerHealth>();
		//vectorP = GameObject.FindGameObjectWithTag ("Player").transform.position;
		//vectorE  = GameObject.FindGameObjectWithTag ("Enemy").transform.position;

		animate = GetComponent<Animator>();

	}

	// Update is called once per frame
	void Update () {

		if (vectorToTarget.magnitude > 1.5 && vectorToTarget.magnitude < 15 && target) {
			//2d turning 
			if(target){//check player object has not been destroyed
			vectorToTarget = target.position - transform.position;
			Quaternion rotation = Quaternion.LookRotation
				(target.transform.position - transform.position, transform.TransformDirection (Vector3.forward));
			float rot = Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

			//transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

			transform.rotation = Quaternion.Euler (0, 0, rot - 90); 
			}

			if (vectorToTarget.magnitude > 10) {
				//move towwards the "player"
				transform.position += transform.up * moveSpeed * Time.deltaTime;

				//////////////////////////////////
				////////////Animation chase start/////////////
				//animate.SetBool ("Run", true);
				/////////////////////////////////
			} else {
				//////annimationstop
				//animate.SetBool ("Throw", false);
		
		}
		}

	}

	void OnCollisionEnter2D(Collision2D other){

		//call the take damage function
		if (other.gameObject.tag == "Player") {

			transform.position += transform.up * -moveSpeed * Time.deltaTime;


		} 

	}


	/*
	void turn(){
		vectorToTarget = target.position -transform.position;
		float atan2 = Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x);
		transform.rotation = Quaternion.Euler (0f, 0f, atan2 * Mathf.Rad2Deg-90);
		//transform.position += transform.right * moveSpeed *Time.deltaTime;
	
	}
	*/
}

