using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpriteShowAttribute : PropertyAttribute {
    int chosenHeight;

    public SpriteShowAttribute(int h)
    {
        chosenHeight = h;
    }

}

public class SpriteShowDrawer:PropertyDrawer
{
    SpriteShowAttribute theAtt = Attribute as SpriteShowAttribute;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label);
    }
}
