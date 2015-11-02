﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float runSpeed;
	public float minJumpHeight;
	public float maxJumpHeight;
	private bool doubleJump;
	private Rigidbody2D myRigidBody2D;
	private float moveVelocity;
	
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask WhatisGround;
	private bool grounded;

	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask WhatisWall;
	private bool walled;
	public float wallPush;
	public float wallJump;
	public bool wallSliding;
	public bool walling;
	public float WallSpeedMax = 10f;
	


	void Start () {
		myRigidBody2D = GetComponent<Rigidbody2D> ();
	}
	
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, WhatisGround);
		walled = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, WhatisWall);
	}
	void Update () {

		//Left and Right Movement
		moveVelocity = 0f;

		if (Input.GetKey (KeyCode.RightArrow)) {
				moveVelocity = runSpeed;
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
				moveVelocity = -runSpeed;
			} 
		if(!walling){
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);
		}

		//wall Sliding
		wallSliding = false;
		if (walled && !grounded && myRigidBody2D.velocity.y < 0) {
			wallSliding = true;
			walling = false;
			if (myRigidBody2D.velocity.y < -WallSpeedMax){
				myRigidBody2D.velocity = new Vector2 (myRigidBody2D.velocity.x, -WallSpeedMax);
			}
		}
		//Jumping
		if (grounded) {
			doubleJump = false;
			walling = false;
		}

			if (Input.GetKeyDown (KeyCode.UpArrow) && grounded) {
				Jump ();
		} else if(Input.GetKeyDown (KeyCode.UpArrow) && !grounded && walled){
			doubleJump = false;
			walling = true;
			if(transform.rotation.y == 0){
				myRigidBody2D.velocity = new Vector2 (-wallPush, wallJump);
			} else if (transform.rotation.y != 0){
				myRigidBody2D.velocity = new Vector2 (wallPush, wallJump);
			}
		}
		else if (Input.GetKeyDown (KeyCode.UpArrow) && !doubleJump && !grounded){
			walling = false;
			Jump ();
			doubleJump = true;
		} 
		if (Input.GetKeyUp (KeyCode.UpArrow) && !wallSliding) {
			if(myRigidBody2D.velocity.y > minJumpHeight){
			myRigidBody2D.velocity = new Vector2(myRigidBody2D.velocity.x, minJumpHeight);
			}
		}

		//turning
		if (myRigidBody2D.velocity.x > 0) {
			transform.rotation = Quaternion.Euler (0, 0, 0);
		} else if (myRigidBody2D.velocity.x < 0) {
			transform.rotation = Quaternion.Euler (0, 180, 0);
		}
		}

	public void Jump(){
		myRigidBody2D.velocity =  new Vector2 (myRigidBody2D.velocity.y,maxJumpHeight);
	}

}
