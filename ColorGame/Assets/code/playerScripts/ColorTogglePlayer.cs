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
            //Color enemyColor = new Color(mat[color].r, mat[color].g, mat[color].b, 1f);
            print("memes");
            /*(Hashtable tweenParams = new Hashtable();
            tweenParams.Add("from", colors[curColor]);
            tweenParams.Add("to", colors[newColor]);
            tweenParams.Add("time", 1f);
            tweenParams.Add("onupdate", "OnColorUpdated");

            iTween.ColorTo(rend.gameObject, tweenParams);
            //rend.color = colors[newColor];*/

            iTween.ColorTo(gameObject, colors[newColor], 0.25f);
            print("dreams");
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
