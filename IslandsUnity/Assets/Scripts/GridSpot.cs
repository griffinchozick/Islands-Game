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

    public bool IsEmpty => SpotMaterial == Material.Empty;
    public Material SpotMaterial = Material.Empty;

    public string id;

    void Start()
    {
        id = transform.position.x.ToString() + transform.position.y.ToString();
    }
}
