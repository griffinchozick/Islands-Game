using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//[CreateAssetMenu(menuName = "BuildingChecker")]
public class BuildingChecker : ScriptableObject
{
    Dictionary<MaterialColor, List<Vector2Int>> rotationCopy;
    public (List<Vector2Int>, BuildingObject) CheckForBuilding(BuildingObject[] buildings, Island island, Vector2Int location, MaterialColor placedColor)
    {
        //Checks if any of the buildings in buildings can be built at the location specified for the give island
        foreach (var building in buildings)
        {
            var spotsUsed = CompletedBuildingSpots(building.buildingBlueprint, island, location, placedColor);
            if (spotsUsed != null)
                return (spotsUsed, building);
        }
        return (null, null);
    }

    private Vector2Int Rotate(Vector2Int coord, int rotations)
    {
        if (rotations == 0)
            return coord;
        Vector2Int result = new Vector2Int(coord.x, coord.y);
        for (int i=0; i<rotations;i++)
        {
            int tempY = result.y;
            result.y = -result.x;
            result.x = tempY;
        }
        return result;
    }
    private void Rotate(Dictionary<MaterialColor, List<Vector2Int>> blueprint)
    {
        foreach (KeyValuePair<MaterialColor, List<Vector2Int>> pair in blueprint)
        {
            for (int i = 0; i < pair.Value.Count; i++)
            {
                pair.Value[i] = new Vector2Int(pair.Value[i].y, -pair.Value[i].x);
            }
        }
    }

    private void AssignBlueprintCopy(BlueprintObject blueprint)
    {
        rotationCopy = new Dictionary<MaterialColor, List<Vector2Int>> {
            { MaterialColor.Blue, new List<Vector2Int>()},
            { MaterialColor.Purple, new List<Vector2Int>()},
            { MaterialColor.Red, new List<Vector2Int>()},
            { MaterialColor.Yellow, new List<Vector2Int>()}
        };

        foreach (MaterialColor color in Enum.GetValues(typeof(MaterialColor)))
        {
            if (color == MaterialColor.None)
                continue;
            foreach (Vector2Int spot in blueprint.GetSpots(color))
                rotationCopy[color].Add(spot);
        }
    }
    private List<Vector2Int> CompletedBuildingSpots(BlueprintObject bpObj, Island island, Vector2Int location, MaterialColor placedColor)
    {
        AssignBlueprintCopy(bpObj);
        //Returns What spaces the building will be built on
        //If returns null it means there were no buildings that could be built
        for (int i = 0; i < 4; i++)
        {
            foreach (Vector2Int baseSpot in rotationCopy[placedColor])
            {
                bool validConstruction = true;
                foreach (MaterialColor keyColor in rotationCopy.Keys)
                {
                    foreach (var spot in rotationCopy[keyColor])
                    {
                        Vector2Int spotToCheck = location + (spot - baseSpot);
                        validConstruction = CheckForMat(spotToCheck, island, keyColor);
                        if (!validConstruction)
                            break;
                    }
                    if (!validConstruction)
                        break;
                }

                if (validConstruction)
                {
                    //Every material was valid in constucting a building
                    Debug.Log("Good Construction");
                    List<Vector2Int> spotsUsed = new List<Vector2Int>();
                    foreach (MaterialColor keyColor in rotationCopy.Keys)
                        foreach (var spot in rotationCopy[keyColor])
                            spotsUsed.Add(location + (spot - baseSpot));                
                    return spotsUsed;
                }
            }
            Rotate(rotationCopy);
        }
        return null;
    }

    private bool CheckForMat(Vector2Int location, Island island, MaterialColor color)
    {
        if (!island.OnGrid(location) || island.IsEmpty(location) || island.AtGrid(location).materialData == null)
            return false;
        else if (((Material)island.AtGrid(location)).materialData.color == color)
            return true;
        return false;
    }

}