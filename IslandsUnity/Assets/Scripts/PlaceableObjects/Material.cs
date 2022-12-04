using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Material : Placeable
{
    //Rewrite this once start using pooling
    public void OnEnable()
    {
        SetSprite(materialData.materialSprite);
    }
}
