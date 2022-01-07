using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MVC Model for IslandController
public class Island : MonoBehaviour
{
    public int islandDimensions = 4;
    public GameObject gridSpotPrefab;

    private GridSpot currentGridSpot;
    public GridSpot CurrentGridSpot { 
        get
        {
            if (currentGridSpot == null) { currentGridSpot = Grid[0, 0]; }
            return currentGridSpot;
        }
        set { currentGridSpot = value; }}

    private GridSpot[,] grid;


    public GridSpot[,] Grid { 
        get {
            if (grid != null) return grid;
            grid = new GridSpot[islandDimensions, islandDimensions];
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    // Instantiate at next postion in grid and sets the island as the parent object.
                    //.5f is to offset them so they algin with the unit grid
                    var newGridSpotObj = Instantiate(gridSpotPrefab, new Vector3(i + .5f, j + .5f, 0), Quaternion.identity);
                    grid[i, j] = newGridSpotObj.GetComponent<GridSpot>();
                    grid[i, j].Coordinates = new Vector2Int(i, j);
                    newGridSpotObj.transform.SetParent(transform, false);
                }
            }
            return grid;
        } 
    }
    
    public GridSpot GetNewCurrentSpot(Vector2Int direction)
    {
        //Changes currentGridSpot to the gridspot in the direction passed in and returns the new currentspot

        //Checks if new value is inbounds
        Vector2Int targetPos = CurrentGridSpot.Coordinates + direction;
        if (0 <= targetPos.x && targetPos.x < islandDimensions
            && 0 <= targetPos.y && targetPos.y < islandDimensions)
        {
            CurrentGridSpot = Grid[targetPos.x,targetPos.y];
        }
        return CurrentGridSpot;
    }
}




