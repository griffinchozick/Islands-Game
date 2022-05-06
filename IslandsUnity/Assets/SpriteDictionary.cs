using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDictionary : MonoBehaviour
{
    public static Dictionary<Material.MatType, Sprite> materialDictionary;
    private void Awake()
    {
        Sprite redMatSprit = Resources.Load<Sprite>("Sprites/mat-red");
        Sprite blueMatSprite = Resources.Load<Sprite>("Sprites/mat-blue");
        Sprite greenMatSprite = Resources.Load<Sprite>("Sprites/mat-green");

        materialDictionary = new Dictionary<Material.MatType, Sprite>();
        materialDictionary.Add(Material.MatType.Red, redMatSprit);
        materialDictionary.Add(Material.MatType.Blue, blueMatSprite);
        materialDictionary.Add (Material.MatType.Green, greenMatSprite);
    }
}
