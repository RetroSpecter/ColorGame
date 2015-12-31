using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {
	public GameObject player;
    public Camera cam;
	// Use this for initialization
	void Start () {
        if (cam == null)
        {
            cam = Camera.main;
        }

        if (cam == null)
        {
            this.enabled = false;
        }
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, this.transform.position.z);
        transform.localScale = new Vector3(cam.orthographicSize * (Screen.width / Screen.height) * 0.45f, cam.orthographicSize * (Screen.width / Screen.height) * 0.45f, 1);

    }
}
