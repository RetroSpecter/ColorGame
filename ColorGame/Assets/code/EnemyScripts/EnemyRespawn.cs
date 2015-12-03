using UnityEngine;
using System.Collections;

public class EnemyRespawn : MonoBehaviour {

    public GameObject Spawner;

	// Use this for initialization
	void Start () {
        Instantiate(Spawner, this.transform.position, this.transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
