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

    [SerializeField] private SpriteRenderer spriteRenderer;
    public bool IsEmpty => SpotMaterial == Material.Empty;
    public Material SpotMaterial = Material.Empty;

    public Vector2Int Coordinates;

    void Start()
    {
       
    }

    public void Highlight(bool alreadyHighlighted)
    {
        float opacity = (alreadyHighlighted)?1f : 0f;
        spriteRenderer.color = new Color(1f, 1f, 1f, opacity);
    }
}
