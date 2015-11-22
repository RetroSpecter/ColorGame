using UnityEngine;
using System.Collections;

public class Stomp : MonoBehaviour {

	public float bounceOnEnemy;
	private Rigidbody2D myrigidbody2D;
	private PlayerController playerController;

	// Use this for initialization
	void Start () {
		myrigidbody2D = transform.parent.GetComponent<Rigidbody2D> ();
		playerController = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy" && this.transform.position.y > other.transform.position.y) {
			myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, bounceOnEnemy);
			playerController.doubleJump = false;
			Destroy (other.gameObject);
		}
	}
}
