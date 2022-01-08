using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class IslandController : MonoBehaviour
{

    [SerializeField] GridSelector gridSelector;
    [SerializeField] MaterialPreview materialPreview;
    [SerializeField] Island island;

    private void Start()
    {
        UpdateGridSpot();
        UpdateMaterialPreview();
    }

    public void UpdateGridSpot() => gridSelector.SelectMoveSpot(island.CurrentGridSpot);
    public void UpdateGridSpot(Vector2 direction ) => gridSelector.SelectMoveSpot(island.GetNewCurrentSpot(Vector2Int.CeilToInt(direction)));


    public void TryPlaceMaterial() {
        if (island.CurrentGridSpot.HasMaterial) {
            Debug.LogWarning("Trying to place on occupied spot");
            gridSelector.CantSelectFeedback();
            return;
        }
        island.PlaceUpcomingMaterial();
        UpdateMaterialPreview();

        //if problems tryn using a function with a bool out to see if island succesfully executed its function      
    }

    void UpdateMaterialPreview() => materialPreview.PreviewNextMat(island.UpcomingMaterial);


}
