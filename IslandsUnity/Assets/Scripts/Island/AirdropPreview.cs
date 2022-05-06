using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MVC View for IslandController
public class AirdropPreview : MonoBehaviour
{
    [SerializeField] MaterialGenerator materialGenerator;
    [SerializeField] AirdropRenderer airdropRenderer;

    public Material nextMaterial;

    //Number Material that the airdrop is currently getting from the generator
    private int currentGeneratorIndex = 0;

    public void Start()
    {
        GetNewMaterial();
    }
    public void GetNewMaterial()
    {
        nextMaterial = materialGenerator.GetMaterial(currentGeneratorIndex);
        currentGeneratorIndex++;
        airdropRenderer.UpdatePreview();
    }
}
