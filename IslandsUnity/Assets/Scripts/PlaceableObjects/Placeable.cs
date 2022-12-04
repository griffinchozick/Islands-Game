using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeable : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    public MaterialObject materialData = null;
    public Vector2Int location = new Vector2Int(-1,-1);
    public void SetSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
}
