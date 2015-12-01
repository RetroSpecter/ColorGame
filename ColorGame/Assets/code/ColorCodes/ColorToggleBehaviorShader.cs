using UnityEngine;
using System.Collections;

public class ColorToggleBehaviorShader : MonoBehaviour
{



    public string[] mat = new string[4];
    public Color myColor = new Color(0f,0f,0f,1f);

    private SpriteRenderer rend;
    private Collider2D coll;
    private ColorManager CM;
    private bool isOn;
    private int color;
    public bool usingSecondaryColor;
    public GameObject blockParticle;
    // Awake
    void Awake()
    {
        CM = GameObject.Find("GameManager").GetComponent<ColorManager>();
        coll = this.GetComponent<Collider2D>();
        rend = this.GetComponent<SpriteRenderer>();
        // Start the event listener
        //if (usingSecondaryColor) {
        //CM.OnSecondaryColorChange += OnColorChange;
        //}
        //else { 
        CM.OnColorChange += OnColorChange;
        //}
        OnColorChange((int)CM.curUsingColor);
    }
    public bool[] activeColors = { true, false, false, false };
    public void OnColorChange(int col)
    {
        color = col;
        //if we changed to a color we are on for, and are not currently on
        if (activeColors[col] && !isOn)
        {
            turnOn();
        }
        //if we are not on for this color
        else if (!(activeColors[col]))
        {
            turnOff();
        }
    }

    public void turnOn()
    {
        isOn = true;
        if (coll) { coll.enabled = true; }
        changeTexture();

        spawnParticle();
    }

    public void turnOff()
    {
        isOn = false;
        if (coll) {
            coll.enabled = false;
    
            GetComponent<Renderer>().material.SetColor("_Color", Color.grey);
        }

    }

    public void changeTexture()
    {
        if (rend != null)
        {
            if (rend) { rend.enabled = true; }

            if (mat[color] != null)
            {
                Color enemyColor = new Color (myColor.r,myColor.g,myColor.b,1f);
                GetComponent<Renderer>().material.SetColor("_Color", enemyColor);
            }
            else if (rend) { rend.enabled = false; }
        }

    }

    public void spawnParticle()
    {
        if (blockParticle != null && rend != null)
        {
            Instantiate(blockParticle, transform.position, Quaternion.Euler(270, 0, 0));
        }
    }

}
