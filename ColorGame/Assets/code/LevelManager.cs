﻿using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject CurrentCheckpoint;
	private PlayerController player;
	public float respawnDelay;
	private CameraBehavior camera;
	public GameObject respawnParticle;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		camera = FindObjectOfType<CameraBehavior> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			RespawnPlayer ();
		}
	}

	public void RespawnPlayer(){
			StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo(){
		player.enabled = false;
		player.playerObject.GetComponent<Renderer> ().enabled = false;
		camera.isFollowing = false;
		//player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		player.GetComponent<Rigidbody2D> ().gravityScale = 0;
		yield return new WaitForSeconds(respawnDelay);
		player.transform.position = CurrentCheckpoint.transform.position;
		player.enabled = true;
		camera.isFollowing = true;
		player.playerObject.GetComponent<Renderer> ().enabled = true;
		player.GetComponent<Rigidbody2D> ().gravityScale = 3;
		player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, 15);
		Instantiate(respawnParticle,CurrentCheckpoint.transform.position, CurrentCheckpoint.transform.rotation);
		camera.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y,camera.transform.position.z);
		}
	public void EndLevel(){
		player.enabled = false;
		player.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0,0,0);
		player.GetComponent<Rigidbody2D> ().AddForce (transform.right * 5f);
	}

}
