using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    public int islandDimensions = 4;
    public GameObject gridSpotPrefab;

    private GameObject[,] grid;
    public GameObject[,] Grid { get { return grid; } 
        //Fills in the grid with empty gridspots
        private set {
            int length = value.GetLength(0);
            int length2 = value.GetLength(1);
            grid = new GameObject[length, length2];
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length2; j++)
                {
                    // Instantiate at next postion in grid and sets the island as the parent object.
                    var newGridSpot= Instantiate(gridSpotPrefab, new Vector3(i, j, 0), Quaternion.identity);
                    grid[i, j] = newGridSpot;
                    newGridSpot.transform.SetParent(transform, false);
                }
            }
        }
    }
    void Start()
    {
        Grid = new GameObject[islandDimensions, islandDimensions];
    }



}
