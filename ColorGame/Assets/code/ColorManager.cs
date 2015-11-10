using UnityEngine;
using System.Collections;
using System.Linq;

public class ColorManager : MonoBehaviour {

    public KeyCode key_SelectColor_Red;
    public KeyCode key_SelectColor_Green;
    public KeyCode key_SelectColor_Blue;
    //public KeyCode key_ToggleColorRotation;

	public enum GameColor {White, Red, Green, Blue};
    public GameColor curUsingColor; //state we are in
	//public GameColor curSelectableColor; //state we can change to
    public bool[] onColors = { true, false, false, false };
	
    public delegate void OnColorEvent(int color);
    public event OnColorEvent OnColorChange;
    //public event OnColorEvent OnSecondaryColorChange;


    //[SerializeField] private bool rotatingColors;
    //public float rotateEveryXSeconds;
    //private float secondsUntilRotation;
    
    // Use this for initialization
	void Start () {
        //rotateColor();
        //secondsUntilRotation = rotateEveryXSeconds;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(key_SelectColor_Red) && onColors[1]) {
            changeColor(GameColor.Red);
        }
        else if (Input.GetKeyDown(key_SelectColor_Green) && onColors[2]) {
            changeColor(GameColor.Green);
        }
        else if (Input.GetKeyDown(key_SelectColor_Blue) && onColors[3]) {
            changeColor(GameColor.Blue);
        }

	}

    public void changeColor(GameColor newColor) {
        if (newColor == curUsingColor) {
            curUsingColor = GameColor.White;
        }
        else {
            curUsingColor = newColor;
        }
        OnColorChange((int)curUsingColor);
    }


}
