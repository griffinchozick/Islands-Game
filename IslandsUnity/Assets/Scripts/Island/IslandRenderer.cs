using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Updates Sprites to match island data
public class IslandRenderer : MonoBehaviour
{
    [SerializeField] Island island;
    
    public SpriteRenderer[] spotRenderers;
    public SpriteRenderer[] spotMatRenderers;

    private int Vector2IntToIndex(Vector2Int vector)
    {
        return vector.x + vector.y * 5;
    }
    public void UpdateSpotMaterial(Vector2Int location)
    {
        Material loactionMat = island.Grid[location.x, location.y];
        //Updates sprite renderer at <location> on grid
        //Updates Materials on that location and selector icon for current grid spot
        if (loactionMat == null)
            spotMatRenderers[Vector2IntToIndex(location)].sprite = null;
        else
        {
            spotMatRenderers[Vector2IntToIndex(location)].sprite = SpriteDictionary.materialDictionary[loactionMat.type];
        }
    }

    public void UpdateSpotSelector(Vector2Int location)
    {
        bool shouldSelect = island.currentGridSpot == location;
        spotRenderers[Vector2IntToIndex(location)].enabled = !shouldSelect;
    }
    public void RenderIsland()
    {
        UpdateSpotSelector(island.currentGridSpot);
    }
}
