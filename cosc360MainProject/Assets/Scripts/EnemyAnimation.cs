﻿using UnityEngine;
using System.Collections;

public class EnemyAnimation : MonoBehaviour {

	// An array with the sprites used for animation
	public Sprite[] animSprites;

	// Controls how fast to change the sprites when
	// animation is running
	public float framesPerSecond;

	// Reference to the renderer of the sprite
	// game object
	SpriteRenderer animRenderer;


	// Time passed since the start of animatin
	private float timeAtAnimStart;

	// Indicates whether animation is running or not
	private bool animRunning = false;



	// Speed of the movement
	public float speed = 4f;

	// Direction of the movement
	private float movementDir;


	// Use this for initialization
	void Start () {
		// Get a reference to game object renderer and
		// cast it to a Sprite Rendere
		animRenderer = GetComponent<Renderer>() as SpriteRenderer;

	}


	// At fixed time intervals...
	void FixedUpdate () {



		}



	// Before rendering next frame...
	void Update () {

		// Record time at animation start
		timeAtAnimStart = Time.timeSinceLevelLoad;


			// Animation is running, so we need to 
			// figure out what frame to use at this point
			// in time

			// Compute number of seconds since animation started playing
			float timeSinceAnimStart = Time.timeSinceLevelLoad - timeAtAnimStart;

			// Compute the index of the next frame    
			int frameIndex = (int) (timeSinceAnimStart * framesPerSecond);


		if(frameIndex < animSprites.Length) {
				// Let the renderer know which sprite to
				// use next      
				animRenderer.sprite = animSprites[ frameIndex ];

			} else {
				// Animation finished, set the render
				// with the first sprite and stop the 
				// animation
				animRenderer.sprite = animSprites[0];
			}
		}

}




