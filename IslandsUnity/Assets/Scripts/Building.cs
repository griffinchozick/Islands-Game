using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Placeable
{
    public BuildingObject buildingData;
    public string Color;
    
    int constructionIndex = 0;

    //Rewrite this once start using pooling
    public void OnEnable()
    {
        SetSprite(buildingData.buildingSprite);
    }

    public void Construct(IslandController islandController)
    {
        // It needs to break after timeout action so that it doesn't continue constructing
        //until timeout is done. So it pauses construction and the timedAction callback continues
        // construction
        while (constructionIndex < buildingData.constructionActions.Length)
        {
            BuildingAction nextAction = buildingData.constructionActions[constructionIndex];
            nextAction.PerformAction(islandController, this);
            constructionIndex++;
            if (nextAction is TimedBuildingAction)
                break;
        }
    }
}
