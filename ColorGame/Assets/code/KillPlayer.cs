using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		
		levelManager.RespawnPlayer(); 
		AudioManager.instance.playSound(0);
		
	}
}
