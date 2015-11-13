using UnityEngine;
using System.Collections;

public class PlayerOrbBehavior : MonoBehaviour {

    public GameObject colorObject;
    private SpriteRenderer rend;
    private ColorManager CM;

    private Animator anim;
    private bool isOn;

    public enum GameColor { White, Red, Green, Blue };
    public GameColor curUsingColor; //state we are in

    void Awake() {
        CM = GameObject.Find("GameManager").GetComponent<ColorManager>();
        rend = colorObject.GetComponent<SpriteRenderer>();
        anim = this.GetComponent<Animator>();
        // Start the event listener
        CM.OnColorChange += OnColorChange;

        OnColorChange((int)curUsingColor);
    }


    
    public void OnColorChange(int col) {
        //if we changed to a color we are on for, and are not currently on
        if ((int)curUsingColor == (int)CM.curUsingColor) {
            turnOn();
        }
        //if we are not on for this color
        else {
            turnOff();
        }
    }

    public void turnOn() {
        isOn = true;
        rend.enabled = true;
        //anim.animation = orbAnim
        anim.SetBool("Rotating", true);
    }

    public void turnOff() {
        isOn = false;
        rend.enabled = false;
        anim.SetBool("Rotating", false);
    }

}
