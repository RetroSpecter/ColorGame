using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_ColorView : MonoBehaviour {
    ColorManager cm;
    Text t;
	// Use this for initialization
	void Start () {
	    cm = GameObject.Find("GameManager").GetComponent<ColorManager>();
        t = this.GetComponent<Text>();
        t.supportRichText = true;
	}
	
	// Update is called once per frame
	void Update () {
        Color textColor;
        string curColorName;
        int curColor = (int)cm.curSelectableColor;
        if(curColor == 0) {textColor = Color.white; curColorName = "white";}
        else if (curColor == 1) {textColor = Color.red; curColorName = "red";}
        else if (curColor == 2) {textColor = Color.green; curColorName = "green";}
        else { textColor = Color.blue; curColorName = "blue";} //curColor == 3

        //t.color = textColor;
        t.text = (
            "<color="+cm.curUsingColor.ToString()+">" + cm.curUsingColor.ToString() + "</color>"
            + " | " +
            "<color="+curColorName+">" + curColorName + " - " + cm.getSecondsUntilRotation() + "</color>"
            );

	}
}
