using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(AnimationClip))]
public class AnimationClipDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        
        GUI.backgroundColor = CheckIfNull(property)? Color.red : Color.green;
        
        EditorGUI.PropertyField(position, property, GUIContent.none);
        EditorGUI.EndProperty();
    }

    private bool CheckIfNull(SerializedProperty property)
    {
        return property.objectReferenceValue == null;
    }
}
