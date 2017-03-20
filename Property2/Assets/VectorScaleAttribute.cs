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

        EditorGUI.LabelField(drawPos, label);
        drawPos.y += drawPos.height;
        
        changer.x = EditorGUI.Slider(drawPos, property.vector3Value.x, VectAtt.min, VectAtt.max);
        drawPos.y += drawPos.height + 3;
        changer.y = EditorGUI.Slider(drawPos, property.vector3Value.y, VectAtt.min, VectAtt.max);
        drawPos.y += drawPos.height + 3;
        changer.z = EditorGUI.Slider(drawPos, property.vector3Value.z, VectAtt.min, VectAtt.max);

        property.vector3Value = changer;
    }
}
