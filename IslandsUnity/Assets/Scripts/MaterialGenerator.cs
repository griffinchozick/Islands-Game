using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class MaterialGenerator : MonoBehaviour
{
    //The Material List for this round
    [SerializeField] MaterialObject[] materialObjects;
    [SerializeField] GameObject materialPrefab;
    public List<MaterialObject> roundMaterialList;

    public void Start()
    {
        AddEvenBags(5);
    }

    public void AddEvenBags(int bagAmount = 1)
    {
        //Creates a bag (group of materials) with each material prefab appearing exactly once in a random order
        //Its an even bag as all materials have equal occurances

        int numTypesMats = materialObjects.Length;
        for (int i = 0; i < bagAmount; i++)
        {
            List<MaterialObject> newBag = new List<MaterialObject>();
            foreach (var matObj in materialObjects)
            {
                newBag.Add(matObj);
            }
            newBag.Shuffle();
            roundMaterialList.AddRange(newBag);

        }
    }

    //Returns the next material but also removes that material from the list
    public Material GetMaterial(int index)
    {
        while (roundMaterialList.Count <= index){
            AddEvenBags(1);
        }
        Material newMat = Instantiate(materialPrefab).GetComponent<Material>();
        newMat.materialData = roundMaterialList[index];
        return newMat;
    }
}
