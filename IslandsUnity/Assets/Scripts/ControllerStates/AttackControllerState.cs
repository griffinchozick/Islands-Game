using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControllerState : ControllerState
{
    public override bool MainAction(IslandController iController)
    {
        Island island = iController.enemyIsland;
        Vector2Int targetCoords = iController.selectedCoords;

        if (island != iController.currentIsland)
            Debug.LogWarning("Selecting Ally Island");
        else if (!island.CanTakeDamage(targetCoords))
            return false;

        island.TakeDamage(targetCoords);
        
        
        iController.SwitchState(iController.placeMaterialState);
        iController.allyIsland.RemoveObject(iController.activeBuilding.location);
        iController.activeBuilding = null;

        return true;
    }

    public override void EnterState(IslandController iController)
    {
        Debug.Log("State Enterd");
        iController.SwitchIslands(iController.enemyIsland);
    }
}
