using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingAction : ScriptableObject
{
    //Return True if the action was performed
    public abstract void PerformAction(IslandController controller, Building building);
}
