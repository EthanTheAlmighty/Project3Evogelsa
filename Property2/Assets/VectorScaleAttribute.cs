using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class VectorScaleAttribute : PropertyAttribute {
    public float min, max;
    public VectorScaleAttribute(float min, float max)
    {
        this.min = min;
        this.max = max;
    }
}

[CustomPropertyDrawer(typeof(VectorScaleAttribute))]
public class VectorScaleDrawer:PropertyDrawer
{
    Vector3 changer = new Vector3();
    GUIStyle labelStyle = GUI.skin.label;
    GUIStyle coordStyle = GUI.skin.label;

    VectorScaleAttribute VectAtt
    {
        get { return ((VectorScaleAttribute)attribute); }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) * 4 + 6;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //base.OnGUI(position, property, label);
        Rect drawPos = position;
        
        drawPos.height -= 6;
        drawPos.height /= 4;

        Rect labelPos = drawPos;
        labelPos.width = 30;
        drawPos.width -= 40;
        drawPos.x += 40;

        labelStyle.alignment = TextAnchor.MiddleCenter;
        EditorGUI.LabelField(drawPos, label, labelStyle);
        drawPos.y += drawPos.height;
        labelPos.y += drawPos.height;

        labelStyle.alignment = TextAnchor.MiddleRight;
        EditorGUI.LabelField(labelPos, "X", labelStyle);
        changer.x = EditorGUI.Slider(drawPos, property.vector3Value.x, VectAtt.min, VectAtt.max);
        drawPos.y += drawPos.height + 3;
        labelPos.y += drawPos.height + 3;

        EditorGUI.LabelField(labelPos, "Y", labelStyle);
        changer.y = EditorGUI.Slider(drawPos, property.vector3Value.y, VectAtt.min, VectAtt.max);
        drawPos.y += drawPos.height + 3;
        labelPos.y += drawPos.height + 3;

        EditorGUI.LabelField(labelPos, "Z", labelStyle);
        changer.z = EditorGUI.Slider(drawPos, property.vector3Value.z, VectAtt.min, VectAtt.max);

        property.vector3Value = changer;
    }
}
