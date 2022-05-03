using UnityEditor;
using UnityEngine;


[CustomPropertyDrawer(typeof(Blueprint))]
public class BlueprintDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;


        Rect newPostition = position;
        newPostition.y += 18f;

        SerializedProperty flattenedGrid = property.FindPropertyRelative("FlattenedGrid");
        int dim  = property.FindPropertyRelative("BlueprintDimensions").intValue;


        for (int i = 0; i < dim; ++i)
        {
            newPostition.width = position.width/dim;
            newPostition.height = 18f;
            for (int j = 0; j < dim; j++)
            {
                EditorGUI.PropertyField(newPostition, flattenedGrid.GetArrayElementAtIndex((i * dim) + j), GUIContent.none );
                newPostition.x += newPostition.width;
            }

            newPostition.x = position.x;
            newPostition.y += 18f;
        }
        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        //EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("amount"), GUIContent.none);
        //EditorGUI.PropertyField(unitRect, property.FindPropertyRelative("unit"), GUIContent.none);
        //EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("name"), GUIContent.none);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 18f* 20;
    }
}
