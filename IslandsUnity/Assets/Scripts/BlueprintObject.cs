using System;
    using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[CreateAssetMenu(fileName = "Data", menuName = "BlueprintObject")]
public class BlueprintObject : ScriptableObject
{
    /*public Dictionary<string, List<Vector2Int>> blueprint = new Dictionary<string, List<Vector2Int>>()
    {
        {"BLUE", new List<Vector2Int>()},
        {"GREEN", new List<Vector2Int>()},
        {"RED", new List<Vector2Int>()},
        {"YELLOW", new List<Vector2Int>()},
    };
    
     Not using dictionary because couldn't figure out how to serialize or use create asset
    from assetdatabse with it
     */

    [SerializeField] private List<Vector2Int> blue = new List<Vector2Int>();
    [SerializeField] private List<Vector2Int> purple = new List<Vector2Int>();
    [SerializeField] private List<Vector2Int> red = new List<Vector2Int>();
    [SerializeField] private List<Vector2Int> yellow = new List<Vector2Int>();

    public List<Vector2Int> allSpotsUsed = new List<Vector2Int>();
    public List<MaterialColor> AllColors = new List<MaterialColor> { MaterialColor.Blue, MaterialColor.Purple, MaterialColor.Red, MaterialColor.Yellow };



    private List<Vector2Int> ColorToList(MaterialColor color)
    {
        if (color == MaterialColor.Blue)
            return blue;
        else if (color == MaterialColor.Purple)
            return purple;
        else if (color == MaterialColor.Red)
            return red;
        else if (color == MaterialColor.Yellow)
            return yellow;
        else
        {
            Debug.LogWarning("Invalid Material Color parameter for function ColorToList()");
            return null;
        }
    }
    //Geter and setter for "dictionary"
    public List<Vector2Int> GetSpots(MaterialColor color)
    {
        return ColorToList(color);  
    }
    public void AddSpot(MaterialColor color, Vector2Int newSpot)
    {
        ColorToList(color).Add(newSpot);
    }

    public void PrintDict()
    {
        string result = "";
        result += ("Blue: " + blue + "/");
        result += ("Purple: " + purple + "/");
        result += ("Red: " + red + "/");
        result += ("Yellow: " + yellow);
        Debug.Log(result);
    }
}


