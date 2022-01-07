using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class IslandController : MonoBehaviour
{


    private GridSpot currentGridSpot;
    public GridSpot CurrentGridSpot
    {
        get { return currentGridSpot; }
        set
        {
            if (currentGridSpot != value)
            {     
                if (currentGridSpot != null) { currentGridSpot.Highlight(true); }
                currentGridSpot = value;
                currentGridSpot.Highlight(false);
            }
        }
    }
    public Island island;

    // Start is called before the first frame update
    void Start()
    {
        CurrentGridSpot = island.Grid[0, 0];
    }

    // Update is called once per frame
    public void UpdateGridSpot(Vector2 direction)
    {
        Vector2Int targetpos = Vector2Int.CeilToInt(direction) + currentGridSpot.Coordinates;
        if (InBounds(targetpos))
        {
            CurrentGridSpot = island.Grid[targetpos.x,targetpos.y];
        }
    }

    bool InBounds(Vector2Int position)
    {   
        //Insures that x and y value are both with the closed interval of [0, islandDimesion]
        if (0 <= position.x && position.x < island.islandDimensions
            && 0 <= position.y && position.y < island.islandDimensions)
        {
            return true;
        }
        return false;
    }
    [SerializeField] GameObject matprefab;
    public void PlaceMaterial()
    {
        if (!currentGridSpot.IsEmpty) { return; }
        currentGridSpot.ChangeMaterial(GridSpot.Material.Red);

        var newMat = Instantiate(matprefab, new Vector3(0, 0, 0), Quaternion.identity);
        newMat.transform.SetParent(currentGridSpot.transform);
        newMat.transform.localPosition = Vector3.zero;
    }

}
