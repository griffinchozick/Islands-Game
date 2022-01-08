using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpot : MonoBehaviour
{
    //Different Type of Materials that can be present on grid spot


    public SpriteRenderer SpriteRenderer;
    public bool HasMaterial { get { return spotMaterial != null; } }
    Material spotMaterial;
    public Material SpotMaterial { 
        get { return spotMaterial; }
        set
        {
            if(HasMaterial && value != null) {
                Debug.LogWarning("Trying to place a material on a occupied spot");
                return;
            }
            spotMaterial = value;
            if (spotMaterial != null) {
                spotMaterial.Obj.transform.SetParent(transform, false);
               // spotMaterial.Obj.transform.localposition = Vector3.zero;
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
    }
}
