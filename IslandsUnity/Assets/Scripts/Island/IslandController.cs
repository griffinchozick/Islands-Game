using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class IslandController : MonoBehaviour
{
    [SerializeField] AirdropPreview airdropPreview;
    [SerializeField] Island island;
    public void TryPlaceMaterial() {
        //Try to place the next Material in Material Preview, if it succeeds update the material preview
        if (airdropPreview.nextMaterial == null) {
            Debug.LogWarning("AirdropPreview NextMaterial is null");
        }
        bool result = island.PlaceMaterial(airdropPreview.nextMaterial);
        if (!result) {
            return;
        }
        airdropPreview.GetNewMaterial(); 
    }

    public void TryChangeGridSelector(Vector2Int direction)
    {
        //Try to change where the grid selector is
        bool result = island.MoveCurrentGridSpot(direction + island.currentGridSpot);
    }
}
