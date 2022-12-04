using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseBuffControllerState : ControllerState
{
    public override bool MainAction(IslandController iController)
    {
        Debug.LogWarning("NOT IMPLEMENTED");
        return false;
        /*Island island = iController.allyIsland;
        Vector2Int targetCoords = iController.selectedCoords;

        if (island != iController.currentIsland)
            Debug.LogWarning("Selecting Enemy Island");

        if (airdrop.nextMaterial == null)
        {
            Debug.LogWarning("AirdropPreview NextMaterial is null");
            return false;
        }
        else if (!island.CanPlaceObject(targetCoords))
            return false;

        island.PlaceObject(airdrop.nextMaterial, targetCoords);
        iController.TryConstructBuilding(targetCoords);
        airdrop.GetNewMaterial();
        return true;*/
    }

    public override void EnterState(IslandController iController)
    {
        Debug.LogWarning("NOT IMPLEMENTED");
        //iController.SwitchIslands(iController.allyIsland);
    }
}
