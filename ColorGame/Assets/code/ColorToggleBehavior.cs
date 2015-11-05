using UnityEngine;
using System.Collections;

public class ColorToggleBehavior : MonoBehaviour {

    public Material[] mat = new Material[4];

    private Renderer rend;
    private Collider2D coll;
    private ColorManager CM;
    private bool isOn;
    private int color;
    // Awake
    void Awake() {
        CM = GameObject.Find("GameManager").GetComponent<ColorManager>();
        coll = this.GetComponent<Collider2D>();
        rend = this.GetComponent<Renderer>();
        // Start the event listener
        CM.OnColorChange += OnColorChange;
        
        OnColorChange((int)CM.curUsingColor);
    }
    public bool[] activeColors = { true, false, false, false };
    public void OnColorChange(int col) {
        color = col;
        //if we changed to a color we are on for, and are not currently on
        if (activeColors[col] && !isOn) {
            turnOn();
        }
        //if we are not on for this color
        else if (!(activeColors[col])) {
            turnOff();
        }
    }

    public void turnOn() {
        isOn = true;
        coll.enabled = true;
        changeTexture();
        ;
    }

    public void turnOff() {
        isOn = false;
        coll.enabled = false;
        changeTexture();
        ;
    }

    public void changeTexture() {
        rend.enabled = true;
        if (mat[color] != null) {
            rend.material = mat[color];
        }
        else {
            rend.enabled = false;
        }
    }

}
