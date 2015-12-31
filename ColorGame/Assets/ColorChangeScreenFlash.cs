using UnityEngine;
using System.Collections;

public class ColorChangeScreenFlash : MonoBehaviour
{



    public Color[] colors = new Color[5];


    private Renderer rend;
    private Collider2D coll;
    private ColorManager CM;
    private bool isOn;
    private int color;

    // Awake
    void Awake()
    {
        CM = GameObject.Find("GameManager").GetComponent<ColorManager>();
        rend = this.GetComponent<Renderer>();
        // Start the event listener
        //if (usingSecondaryColor) {
        //CM.OnSecondaryColorChange += OnColorChange;
        //}
        //else { 
        CM.OnColorChange += OnColorChange;
        //}
        OnColorChange((int)CM.curUsingColor);
    }
    //public bool[] activeColors = { true, false, false, false };

    public void OnColorChange(int col)
    {
        color = col;
        //if we changed to a color we are on for, and are not currently on
        changeTexture(col);
        spawnParticle();
    }

    public void finishLevel()
    {
        OnColorChange(5);
    }


    public void changeTexture(int col)
    {
        print("changeTint");
        rend.material.SetColor("_TintColor", colors[col]);

        //iTween.ValueTo(gameObject, , );

        //iTween.ColorTo(gameObject, colors[col], 0.25f);
        StartCoroutine("FadeOut");
    }

    IEnumerator FadeOut()
    {
        print("fading");
        float time = 0.5f; //time it should take for the entire 'flash'
        float a = 0;
        float maxA = 0.09f; //most opaque this flash will get (1 - fully opaque, 0 - fully transulcent)

        Color c = rend.material.GetColor("_TintColor");
        c.a = a;

        //bring the opacity up to the maximum value
        while (a < maxA)
        {
            a += Time.deltaTime / (time/2); //print(a + "   a");
            c.a = a;

            rend.material.SetColor("_TintColor", c);
            yield return null;
        }

        //then back down again to 0 (transparent
        while (a > 0)
        {
            a -= Time.deltaTime / (time/2); //print(a + "   a");
            c.a = a;
          
            rend.material.SetColor("_TintColor", c);
            yield return null;
        }
        

    }

public void spawnParticle()
    {
    //    if (blockParticle != null && rend != null)
    //    {
    //        Instantiate(blockParticle, transform.position, Quaternion.Euler(270, 0, 0));
    //    }
    }

}
