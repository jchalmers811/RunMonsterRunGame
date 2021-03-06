﻿/*
	Created by: Lech Szymanski
				lechszym@cs.otago.ac.nz
				Dec 29, 2015			
*/

using UnityEngine;
using System.Collections;

/* This is an example script using A* pathfinding to chase a
 * target game object*/

public class Chase : MonoBehaviour {

	// Target of the chase
	// (initialise via the Inspector Panel)
	public GameObject target = null;
	private Transform targetT;  
	private Vector3 vectorToTarget;
	// Chaser's speed
	// (initialise via the Inspector Panel)
	public float speed;

	// Chasing game object must have a AStarPathfinder component - 
	// this is a reference to that component, which will get initialised
	// in the Start() method
	private AStarPathfinder pathfinder = null; 

	// Use this for initialization
	void Start () {
		//Get the reference to object's AStarPathfinder component
		pathfinder = transform.GetComponent<AStarPathfinder> ();

		//get the "player" as target - transform gives the info we need for this
		targetT = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (pathfinder != null) {
			//Travel towards the target object at certain speed.
			pathfinder.GoTowards(target, speed);
		}

		vectorToTarget = targetT.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation
			(target.transform.position - transform.position, transform.TransformDirection (Vector3.forward));
		float rot = Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

		transform.rotation = Quaternion.Euler (0, 0, rot - 90); 
	}
}
