using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject toSpawn;
    private PlayerController player;
    private bool done;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (player.playerObject.GetComponent<Renderer>().enabled == true)
        {
            done = false;
        }
        if (player.playerObject.GetComponent<Renderer>().enabled == false && !done)
        {
            spawnIn();
            done = true;
        }
        
	}
    public void spawnIn() {
        Instantiate(toSpawn, this.transform.position, this.transform.rotation);
    }
}
