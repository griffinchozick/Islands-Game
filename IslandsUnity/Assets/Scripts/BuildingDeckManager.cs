using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDeckManager : MonoBehaviour
{
    //Get rid of this oncce implement object pooler
    [SerializeField] GameObject buildingPrefab;


    public BuildingObject[] buildingDeck;
    public Building GetBuilding(int index)
    {
        if (index < 0 || index >= buildingDeck.Length)
        {
            Debug.LogWarning("Index outside of building deck range");
            return null;
        }
        //Get rid of this oncce implement object pooler
        Building building = Instantiate(buildingPrefab).GetComponent<Building>();
        building.buildingData = buildingDeck[index];
        building.enabled = true;
        return building;
    }
}
     