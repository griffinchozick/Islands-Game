using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingCard : MonoBehaviour
{
    [SerializeField] Image thumbnail;
    [SerializeField] Image[] materialImages;
    [SerializeField] BuildingObject buildingData;
    [SerializeField] MaterialColorToData colorDataConverter;
    void Start()
    {
        if(buildingData == null)
        {
            Debug.LogError("No Building Data for Building Card!");
            return;
        }
        BlueprintObject blueprint = buildingData.buildingBlueprint;
        thumbnail.sprite = buildingData.buildingSprite;
        foreach (MaterialColor color in blueprint.AllColors)
        {
            foreach(Vector2Int spot in blueprint.GetSpots(color))
            {
                int index = CoordToIndex(spot);
                materialImages[index].enabled = true;
                materialImages[index].sprite = colorDataConverter.GetData(color).materialSprite;
            }
        }
    }

    private int CoordToIndex(Vector2Int coordinate)
    {
        return coordinate.x + (coordinate.y * 3) + 4;
    }
}
