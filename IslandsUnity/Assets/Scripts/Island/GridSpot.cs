using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpot : MonoBehaviour
{
    //Different Type of Materials that can be present on grid spot
    public enum Material
    {
        Empty,
        Red,
        Blue
    }

    public SpriteRenderer SpriteRenderer;
    public bool IsEmpty => SpotMaterial == Material.Empty;
    public Material SpotMaterial = Material.Empty;

    public Vector2Int Coordinates;

    public bool highlighted = false;

    public void ToggleSpotSelector()
    {
        highlighted = !highlighted;
        float opacity = (highlighted) ? 0f : 1f;
        SpriteRenderer.color = new Color(1f, 1f, 1f, opacity);
    }



    public void ChangeMaterial(Material newMat)
    {
        SpotMaterial = newMat;
    }
}
