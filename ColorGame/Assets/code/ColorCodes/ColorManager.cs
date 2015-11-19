using UnityEngine;
using System.Collections;
using System.Linq;

public class ColorManager : MonoBehaviour {

    public static ColorManager instance;


    public KeyCode key_SelectColor_Red;
    public KeyCode pad_SelectColor_Red;
    public KeyCode key_SelectColor_Green;
    public KeyCode pad_SelectColor_Green;
    public KeyCode key_SelectColor_Blue;
    public KeyCode pad_SelectColor_Blue;
    //public KeyCode key_ToggleColorRotation;

	public enum GameColor {White, Red, Green, Blue};
    public GameColor curUsingColor; //state we are in
	//public GameColor curSelectableColor; //state we can change to
    public bool[] onColors = { true, false, false, false };
	
    public delegate void OnColorEvent(int color);
    public event OnColorEvent OnColorChange;

    public delegate void AddColorEvent(int color);
    public event AddColorEvent AddNewColor;
    //public event OnColorEvent OnSecondaryColorChange;


    //[SerializeField] private bool rotatingColors;
    //public float rotateEveryXSeconds;
    //private float secondsUntilRotation;
    
    // Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("TurnRed") && onColors[1]) {
            changeColor(GameColor.Red);
        }
        else if (Input.GetButtonDown("TurnGreen") && onColors[2]) {
            changeColor(GameColor.Green);
        }
        else if (Input.GetButtonDown("TurnBlue") && onColors[3]) {
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

    public void addColor(int newColor) {
        //enable new color
        onColors[newColor] = true;
        //change us to the new color
        changeColor((GameColor)newColor);
        //event
        //AddNewColor(newColor);
    }


}
