using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class IslandController : MonoBehaviour
{

    [SerializeField] GridSelector gridSelector;
    [SerializeField] Island island;

    private void Start()
    {
        UpdateGridSpot();
    }

    public void UpdateGridSpot() => gridSelector.SelectMoveSpot(island.CurrentGridSpot);
    public void UpdateGridSpot(Vector2 direction ) => gridSelector.SelectMoveSpot(island.GetNewCurrentSpot(Vector2Int.CeilToInt(direction))); 

    [SerializeField] GameObject matprefab;
    //public void PlaceMaterial()
    //{
    //    if (!currentGridSpot.IsEmpty) { return; }
    //    currentGridSpot.ChangeMaterial(GridSpot.Material.Red);

    //    var newMat = Instantiate(matprefab, new Vector3(0, 0, 0), Quaternion.identity);
    //    newMat.transform.SetParent(currentGridSpot.transform);
    //    newMat.transform.localPosition = Vector3.zero;
    //}

}
