using UnityEngine;
using System.Collections;

public class ColorTogglePlayer : MonoBehaviour
{



    public Color[] mat = new Color[4];


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
        if (activeColors[col])
        {
            turnOn();
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
        if (coll)
        {
            coll.enabled = false;
        }
        changeTexture();

    }

    public void changeTexture()
    {
        if (rend != null)
        {
            Debug.Log("change");
            if (rend) { rend.enabled = true; }

            if (mat[color] != null)
            {
                Color enemyColor = new Color(mat[color].r, mat[color].g, mat[color].b, 1f);
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
