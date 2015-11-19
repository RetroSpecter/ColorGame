using UnityEngine;
using System.Collections;

public class ColorPickupBehavior : MonoBehaviour {

    public ColorManager.GameColor color;
	// Use this for initialization
	void Start () {

	}

    public void Pickup() {
        ColorManager.instance.addColor((int)color);
        Destroy(this.gameObject);
    }
}
