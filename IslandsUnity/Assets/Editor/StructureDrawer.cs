using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Structure))]
public class StructureDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        
        position = EditorGUI.PrefixLabel(position, label);
        

        EditorGUI.EndProperty();
    }
}
