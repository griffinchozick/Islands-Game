using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BlueprintDesignWindow : EditorWindow
{
    [MenuItem("Window/BlueprintDesignWindow")]
    static void OpenWindow()
    {
        BlueprintDesignWindow window = (BlueprintDesignWindow)EditorWindow.GetWindow(typeof(BlueprintDesignWindow));
        window.minSize = new Vector2(400, 200);
        window.Show();
    }

    private BlueprintObject blueprintObject = null;
    MaterialColor[,] blueprintGrid = new MaterialColor[3, 3];
    string assetName;

    public void OnEnable()
    {
        InitData();
    }

    private void OnGUI()
    {
        DrawLayouts();
    }

    private void InitData()
    {
        blueprintObject = CreateInstance<BlueprintObject>();
    }

    public void DrawLayouts()
    {
        GUILayout.Label("Design a Blueprint!");
        assetName = EditorGUILayout.TextField("Blueprint Name: ", assetName);
        for (int j = 2; j >= 0; j--)
        {
            EditorGUILayout.BeginHorizontal();
            for (int i = 0; i < 3; i++)
            {
                blueprintGrid[i, j] = (MaterialColor)EditorGUILayout.EnumPopup(blueprintGrid[i, j]);
            }
            EditorGUILayout.EndHorizontal();
        }
        if (GUILayout.Button("Create Blueprint!"))
        {
            AddBlueprintObjectData();
        }
    }

    private void AddBlueprintObjectData()
    {
        if (assetName == "")
        {
            Debug.LogError("Please enter a name!");
            return;
        }
        if (blueprintGrid[1,1] == MaterialColor.None)
        {
            Debug.LogError("Please design blueprint from middle square");
            return;
        }

        InitData();
 
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                MaterialColor color = blueprintGrid[i, j];
                if (color == MaterialColor.None)
                    continue;
                Vector2Int newSpotCoords = new Vector2Int(i-1, j-1);
                blueprintObject.AddSpot(color, newSpotCoords);
                blueprintObject.allSpotsUsed.Add(newSpotCoords);
            }
        }

    
        string path = "Assets/ScriptableObjects/Blueprints/" + assetName + ".asset";
        AssetDatabase.CreateAsset(blueprintObject, path);
        Debug.Log("Blueprint Created!");



    }
}
