using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject toSpawn;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R)) {
            spawnIn();
        }
	}
    void spawnIn() {
        Instantiate(toSpawn, this.transform.position, this.transform.rotation);
    }
}
