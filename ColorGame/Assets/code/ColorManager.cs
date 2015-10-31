using UnityEngine;
using System.Collections;
using System.Linq;

public class ColorManager : MonoBehaviour {

    public KeyCode key_SelectColor;
    public KeyCode key_ToggleColorRotation;

	public enum GameColor {White, Red, Green, Blue};
    public GameColor curUsingColor; //state we are in
	public GameColor curSelectableColor; //state we can change to

    public delegate void OnColorEvent(int color);
    public event OnColorEvent OnColorChange;

    [SerializeField] private bool rotatingColors;
    public float rotateEveryXSeconds;
    private float secondsUntilRotation;
    
    public bool[] onColors = { true, false, false, false };
	// Use this for initialization
	void Start () {
        rotateColor();
        secondsUntilRotation = rotateEveryXSeconds;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(key_SelectColor)) {
            changeColor(curSelectableColor);
        }

        if (Input.GetKeyDown(key_ToggleColorRotation)) {
            toggleRotation();
        }

        //color rotator
        if (rotatingColors) { 
            if (secondsUntilRotation <= 0) {
                secondsUntilRotation = rotateEveryXSeconds;
                rotateColor();
            }
            secondsUntilRotation -= Time.deltaTime;
        }
	}

    public void changeColor(GameColor newColor) {
        curUsingColor = newColor;
        OnColorChange((int)curUsingColor);
    }

    public void toggleRotation() {
        rotatingColors = !rotatingColors;
        secondsUntilRotation = rotateEveryXSeconds;
    }




    //rotates or current color to the next ON color
    public void rotateColor() {
        //if we haven't unlocked any colors, dont do anything
        if (!(onColors.Count(c => c) <= 1)) {
            int currentColor = (int)curSelectableColor;
            int nextColor= getNextColorInt(currentColor);
            //while (!onColors[nextColor]) {
            //    nextColor = getNextColorInt();
            //}
        
            while (!onColors[nextColor]) {
                nextColor = getNextColorInt(nextColor);
            }
            
            curSelectableColor = (GameColor)nextColor;

        }

    }

    //returns the int value of the color after our current color
    //helper method for rotatecolor();
    private int getNextColorInt(int currentColor) {
        int nextColor;
        
        if (currentColor == 3) { 
            nextColor = 0; 
        } else { 
            nextColor = currentColor + 1; 
        }

        return nextColor;

    }

    public float getSecondsUntilRotation() {
        return secondsUntilRotation;
    }

}
