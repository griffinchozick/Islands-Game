using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MVC View for IslandController
public class MaterialPreview : MonoBehaviour
{
    public void PreviewNextMat(Material nextMat)
    {
        nextMat.transform.SetParent(transform, false);
        nextMat.SpriteRenderer.enabled = true;
    }
}
