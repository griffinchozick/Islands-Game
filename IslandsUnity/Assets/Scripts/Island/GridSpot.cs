using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpot : MonoBehaviour
{
    //Different Type of Materials that can be present on grid spot
    /*

    public SpriteRenderer SpriteRenderer;
    public bool HasMaterial { get { return spotMaterial != null; } }
    Material spotMaterial;
    public Material SpotMaterial { 
        get { return spotMaterial; }
        set
        {
            spotMaterial = value;
            if (spotMaterial != null) {
                spotMaterial.Obj.transform.SetParent(transform, false);

            }
        } 
    }

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
    }*/
}
