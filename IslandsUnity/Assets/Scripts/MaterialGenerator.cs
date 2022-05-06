using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Object Pooler for Materials
public class MaterialGenerator : MonoBehaviour
{
    //The Material List for this round
    public List<Material.MatType> roundMaterialList;

    public void Start()
    {
        AddEvenBag(15);
    }

    public void AddEvenBag(int bagAmount = 1)
    {
        //Creates a bag (group of materials) with each material prefab appearing exactly once in a random order
        //Its an even bag as all materials have equal occurances

        Material.MatType[] nonTrashMaterials = (Material.MatType[])Enum.GetValues(typeof(Material.MatType));
        List<Material.MatType> bag = new List<Material.MatType>();
        for (int i = 1; i < nonTrashMaterials.Length; i++)
        {
            bag.Add(nonTrashMaterials[i]);
        }
        for(int i = 0; i < bagAmount; i++)
        {
            bag.Shuffle();
            roundMaterialList.AddRange(bag);
        }
    }

    //Returns the next material but also removes that material from the list
    public Material GetMaterial(int index)
    {
        while (roundMaterialList.Count <= index){
            AddEvenBag(1);
        }
        return new Material(roundMaterialList[index]);
    }
}
