﻿using UnityEngine;
using System.Collections;

public class PlayerFollow : MonoBehaviour {

	public float moveSpeedModifier = 1f;
	public float turnSpeed = 5f; 
	public Transform target;
	public Transform enemy;
	public Vector3 vectorToTarget;

	private float moveSpeed;
	private EnemyAttack enemyAttack;
	private GameObject Enemy;

	public float attackCooldownTime = 0.3f;
	private float attackCooldown;

	Animator animate;

	// Use this for initialization
	void Start () {
		//get the "player" as target - transform gives the info we need for this
		target = GameObject.FindGameObjectWithTag ("Player").transform;

		enemy = GameObject.FindGameObjectWithTag ("Enemy").transform;
		Enemy = GameObject.FindGameObjectWithTag("Enemy");
		enemyAttack = Enemy.GetComponent<EnemyAttack> ();

		moveSpeed = Random.Range (3, 9) * moveSpeedModifier;

		animate = GetComponent<Animator>();

		}
	
	// Update is called once per frame
	void Update () {

		if (attackCooldown > 0) {
			attackCooldown -= Time.fixedDeltaTime;
		}

		if (target) {
			vectorToTarget = target.position - transform.position;
		}

		//player attacks if in range and cooldown is off. 
		if (attackCooldown <= 0 && vectorToTarget.magnitude <= 2.2 && Enemy) {
			
			enemyAttack.AIAttack ();
			attackCooldown = attackCooldownTime;
			transform.position += transform.up * -moveSpeed * Time.deltaTime;

		} else if (vectorToTarget.magnitude > 2.5 && vectorToTarget.magnitude < 15 && target) {

			////////////Animation chase start/////////////a
				animate.SetBool ("Run", true);
			/////////////////////////////////

			Quaternion rotation = Quaternion.LookRotation
				(target.transform.position - transform.position, transform.TransformDirection (Vector3.forward));
			float rot = Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

			//rotate to face player
			transform.rotation = Quaternion.Euler (0, 0, rot - 90); 

			//move towwards the "player"
			transform.position += transform.up * moveSpeed * Time.deltaTime;




		} else {
			//////annimationstop
			//animate.SetBool ("Run", false);
		} 
	}

//	void OnCollisionEnter2D(Collision2D other){
//
//		//call the take damage function
//		if (other.gameObject.tag == "Player" && attackCooldown <= 0) {
//			//find the enemy object
//			Enemy = GameObject.FindGameObjectWithTag("Enemy");
//			//get the component from the Enemy object
//			enemyAttack = Enemy.GetComponent<EnemyAttack> ();
//			//we now have access to the attack method
//			enemyAttack.AIAttack ();
//			//move towards PLayer
//			transform.position += transform.up * -moveSpeed * Time.deltaTime;
//
//			attackCooldown = attackCooldownTime;
//		} 
//
//	}
//

}


