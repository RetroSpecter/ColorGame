using UnityEngine;
using System.Collections;

public class ToggleEndLevelUI : MonoBehaviour {

	private CanvasGroup canvas;
	public bool visibility;
	private Animator anim;
	public GameObject WinText;

    public string nextLevel;
    public string levelSelect;

	// Use this for initialization
	void Start () {
		canvas = GetComponent<CanvasGroup>();
		anim = WinText.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (visibility == false) {
			canvas.alpha = 0f;
		} else {
			canvas.alpha = 1f;
		}
		anim.SetBool ("Level Beat", visibility);
	}
    public void next()
    {
        Application.LoadLevel(nextLevel);
    }
    public void menu()
    {
        Application.LoadLevel(levelSelect);
    }
}
