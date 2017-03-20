using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpriteShowAttribute : PropertyAttribute {
    public float chosenHeight;

    public SpriteShowAttribute(float h)
    {
        this.chosenHeight = h;
    }

}

[CustomPropertyDrawer(typeof(SpriteShowAttribute))]
public class SpriteShowDrawer:PropertyDrawer
{
    SpriteShowAttribute SpriteAtt
    {
        get { return ((SpriteShowAttribute)attribute); }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + SpriteHeight();
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //base.OnGUI(position, property, label);
        Rect drawPos = position;
        drawPos.height = SpriteAtt.chosenHeight;
        if(property.objectReferenceValue != null)
        {
            Sprite show = property.objectReferenceValue as Sprite;
            GUI.DrawTexture(drawPos, show.texture, ScaleMode.ScaleToFit);

        }

        drawPos = position;
        drawPos.height -= SpriteAtt.chosenHeight;
        drawPos.y += SpriteAtt.chosenHeight;

        EditorGUI.PropertyField(drawPos, property, label);
    }

    public float SpriteHeight()
    {
        SpriteShowAttribute SSA = attribute as SpriteShowAttribute;
        return SSA.chosenHeight;
    }
}
