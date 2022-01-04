using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpot : MonoBehaviour
{
    public string id;

    void Start()
    {
        id = transform.position.x.ToString() + transform.position.y.ToString();
    }
}
