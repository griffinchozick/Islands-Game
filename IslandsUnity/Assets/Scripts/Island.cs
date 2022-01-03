using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island 
{
    public int islandDimensions = 4;
    
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
                    grid[i, j] = new GridSpot();
                }
            }
        }
    }
    public Island()
    {
        Grid = new GridSpot[islandDimensions, islandDimensions];
        islandDimensions = 4;
    }
}
