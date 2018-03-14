using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCycler : MonoBehaviour {

    public Material _initialMaterial;
    float red,
        green,
        blue;
    bool redUp = true,
        greenUp = true,
        blueUp = true;
	
	// Update is called once per frame
	void Update () {
        /*if (redUp)
        {
            red += 0.01f;
            if (red >= 1f)
            {
                redUp = false;
            }
        } else
        {
            red -= 0.01f;
            if (red <= 0f)
            {
                redUp = true;
            }
        }

        if (greenUp)
        {
            green += 0.02f;
            if (green >= 1f)
            {
                greenUp = false;
            }
        }
        else
        {
            green -= 0.02f;
            if (green <= 0f)
            {
                greenUp = true;
            }
        }

        if (blueUp)
        {
            blue += 0.03f;
            if (blue >= 1f)
            {
                blueUp = false;
            }
        }
        else
        {
            blue -= 0.03f;
            if (blue <= 0f)
            {
                blueUp = true;
            }
        }

        _initialMaterial.color = new Color(red, green, blue);
        gameObject.GetComponent<Material>().color = _initialMaterial.color;*/

        red += 0.01f;
        green += 0.02f;
        blue += 0.03f;

        _initialMaterial.color = new Color(Mathf.Abs(Mathf.Sin(red)), Mathf.Abs(Mathf.Sin(green)), Mathf.Abs(Mathf.Sin(blue)));
	}
}
