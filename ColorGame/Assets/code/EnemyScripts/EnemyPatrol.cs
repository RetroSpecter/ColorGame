using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

	public float moveSpeed;
	public bool moveRight;

	public Transform wallCheck;
	public float wallcheckRadius;
	public LayerMask WhatisWall;
	private bool hittingWall;

	public bool notAtEdge;
	public Transform edgeCheck;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallcheckRadius, WhatisWall);

		notAtEdge = Physics2D.OverlapCircle (edgeCheck.position, wallcheckRadius, WhatisWall);

		if (!notAtEdge) {
			moveRight = !moveRight;
		}

		if (moveRight) {
			transform.rotation = Quaternion.Euler(0,180,0);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().transform.position.y);
		} else{
			transform.rotation = Quaternion.Euler(0,0,0);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().transform.position.y);

		}
	}
}
