using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    }

    // Update is called once per frame
    public void UpdateCurrentGridSpot()
    {
        Vector2 screenPosition = Mouse.current.position.ReadValue();
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        if (InBounds(worldPosition))
        {
            Debug.Log(worldPosition);
            CurrentGridSpot = island.Grid[Mathf.FloorToInt(worldPosition.x), Mathf.FloorToInt(worldPosition.y)];
        }
    }

    bool InBounds(Vector2 position)
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
