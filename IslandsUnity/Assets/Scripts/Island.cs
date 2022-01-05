using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    public int islandDimensions = 4;
    public GameObject gridSpotPrefab;

    private GridSpot[,] grid;
    public GridSpot[,] Grid { get { return grid; } 
        //Fills in the grid with empty gridspots
        private set {
            int length = value.GetLength(0);
            int length2 = value.GetLength(1);
            grid = new GridSpot[length, length2];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length2; j++)
                {
                    // Instantiate at next postion in grid and sets the island as the parent object.
                    //.5f is to offset them so they algin with the unit grid
                    var newGridSpotObj= Instantiate(gridSpotPrefab, new Vector3(i +.5f, j +.5f, 0), Quaternion.identity);
                    grid[i, j] = newGridSpotObj.GetComponent<GridSpot>();
                    grid[i, j].Coordinates = new Vector2Int(i, j);
                    newGridSpotObj.transform.SetParent(transform, false);
                }
            }
        }
    }
    void Awake()
    {
        Grid = new GridSpot[islandDimensions, islandDimensions];
    }



}
