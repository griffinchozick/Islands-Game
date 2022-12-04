using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirdropRenderer : MonoBehaviour
{
    [SerializeField] AirdropPreview airdropPreview;

    public Image materialIcon;
    [SerializeField] Image coloredTimerBorder;


    public void UpdatePreview(Sprite newSprite)
    {
        materialIcon.sprite = newSprite;

    }
    public void UpdateTimer(float percentage)
    {
        if (percentage > 1 || percentage < 0)
        {
            Debug.LogError("Not a float between 1 and 0");
            return; 
        }
        coloredTimerBorder.fillAmount = percentage;
    }
}
