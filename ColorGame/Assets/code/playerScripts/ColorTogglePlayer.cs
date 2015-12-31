using UnityEngine;
using System.Collections;

public class ColorTogglePlayer : MonoBehaviour
{
    public Color[] colors = new Color[4];


    private SpriteRenderer rend;
    private Collider2D coll;
    private ColorManager CM;
    private bool isOn;
    private int curColor;
    public GameObject blockParticle;
    // Awake
    void Awake()
    {
        CM = GameObject.Find("GameManager").GetComponent<ColorManager>();
        coll = this.GetComponent<Collider2D>();
        rend = this.GetComponent<SpriteRenderer>();

        CM.OnColorChange += OnColorChange;
        //OnColorChange((int)CM.curUsingColor);
    }
    public void OnColorChange(int col)
    {
        changeTexture(col);
    }


    public void changeTexture(int newColor)
    {
        if (colors[newColor] != null) {
            iTween.ColorTo(gameObject, colors[newColor], 0.25f);
            curColor = newColor;
        }
        

    }

    void Update() {

        //rend.color = Color.Lerp(colors[curColor], colors[newColor], 10f);
    }

    public void spawnParticle()
    {
        /*if (blockParticle != null && rend != null)
        {
            Instantiate(blockParticle, transform.position, Quaternion.Euler(270, 0, 0));
        }*/
    }

}
