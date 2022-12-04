using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BuildingAction/DebugLogAction")]
public class DebugLogAction : BuildingAction
{
    public override void PerformAction(IslandController controller, Building building)
    {   
        Debug.Log(building.name + " is Performing an Action!");
    }
}
