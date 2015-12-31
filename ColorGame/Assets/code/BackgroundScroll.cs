using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, this.transform.position.z);
	}
}
