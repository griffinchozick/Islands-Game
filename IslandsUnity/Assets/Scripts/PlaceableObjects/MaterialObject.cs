using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "MaterialObject")]
public class MaterialObject : ScriptableObject
{
    public Sprite materialSprite;
    public MaterialColor color;

}
