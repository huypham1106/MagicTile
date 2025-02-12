using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Utilities 
{
    public static void ClearTransform(Transform transform)
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public static void SetAlpha(float alphaValue, Image image)
    {
        Color newColor = image.color;
        newColor.a = alphaValue / 255f; ;
        image.color = newColor;
    }

    public static void SetTextColor(Text txt, float r, float g, float b, float a)
    {

        Color newColor = new Color(r / 255f, g / 255f, b / 255f, a / 255f);

        txt.color = newColor;
    }

    public static MapSO LoadMapSO(int level)
    {
        string path = "Map/" + level.ToString();
        MapSO map = Resources.Load<MapSO>(path);
        return map;
    }
}
