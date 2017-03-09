using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ColorLineAttribute : PropertyAttribute {
    public Color lineColor = Color.red;
    public float r, g, b;
    public ColorLineAttribute(float a, float c, float e)
    {
        r = Mathf.Clamp(a, 0f, 1f);
        g = Mathf.Clamp(c, 0f, 1f);
        b = Mathf.Clamp(e, 0f, 1f);
        lineColor = new Color(r, g, b);
    }
}

[CustomPropertyDrawer(typeof(ColorLineAttribute))]
public class ColorLineDrawer:DecoratorDrawer
{
    ColorLineAttribute ColorAtt
    {
        get { return ((ColorLineAttribute)attribute); }
    }

    public override float GetHeight()
    {
        return 6f;
    }

    public override void OnGUI(Rect position)
    {
        Rect drawPos = position;

        //base.OnGUI(position);
        Color oldGuiColor = GUI.color;
        GUI.color = ColorAtt.lineColor;
        EditorGUI.DrawPreviewTexture(drawPos, Texture2D.whiteTexture);
        GUI.color = oldGuiColor;
    }
}
