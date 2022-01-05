using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class GridSelector : MonoBehaviour
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
            Debug.Log(targetpos);
            CurrentGridSpot = island.Grid[targetpos.x,targetpos.y];
        }
    }

    bool InBounds(Vector2Int position)
    {   
        //Insures that x and y value are both with the closed interval of [0, islandDimesion]
        if (Mathf.Abs(2 * position.x - island.islandDimensions) <= island.islandDimensions
            && Mathf.Abs(2 * position.y - island.islandDimensions) <= island.islandDimensions)
        {
            return true;
        }
        return false;


    }
    


}
