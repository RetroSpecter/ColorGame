using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float runSpeed;
	public float jumpHeight;
	public float maxJumpHeight;
	private Rigidbody2D myRigidBody2D;
	private float moveVelocity;
	
	public Transform groundCheck;
	public float groundcheckRadius;
	public LayerMask WhatisGround;
	private bool grounded;


	void Start () {
		myRigidBody2D = GetComponent<Rigidbody2D> ();
	}
	
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundcheckRadius, WhatisGround);
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
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);



			//Jumping
			if (Input.GetKeyDown (KeyCode.UpArrow) && grounded) {
				Jump ();
			}
	
		}
	public void Jump(){
		myRigidBody2D.velocity = new Vector2 (myRigidBody2D.velocity.y,jumpHeight);
	}
}
