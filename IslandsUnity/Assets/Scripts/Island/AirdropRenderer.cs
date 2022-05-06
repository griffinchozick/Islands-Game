using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirdropRenderer : MonoBehaviour
{
    [SerializeField] AirdropPreview airdropPreview;

    public Image materialIcon;

    public void UpdatePreview()
    {
        materialIcon.sprite = SpriteDictionary.materialDictionary[airdropPreview.nextMaterial.type];
        //Updates Airdrop Preview Sprites
    }
}
