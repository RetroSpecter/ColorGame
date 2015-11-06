using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_ColorToggleBehavior : MonoBehaviour {

    public Sprite[] mat = new Sprite[4];

    private Image rend;
    //private Collider2D coll;
    private ColorManager CM;
    private bool isOn;
    private int color;
    public bool usingSecondaryColor;
    // Awake
    void Awake() {
        CM = GameObject.Find("GameManager").GetComponent<ColorManager>();
        rend = this.GetComponent<Image>();
        
        // Start the event listener
        if (usingSecondaryColor) {
            CM.OnSecondaryColorChange += OnColorChange;
        }
        else {
            CM.OnColorChange += OnColorChange;
        }
        OnColorChange((int)CM.curUsingColor);
    }
    //public bool[] activeColors = { true, false, false, false };
    public void OnColorChange(int col) {
        color = col;
        rend.sprite = mat[color];
    }

}
