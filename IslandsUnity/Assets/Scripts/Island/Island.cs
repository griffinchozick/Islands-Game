using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MVC Model for IslandController
public class Island : MonoBehaviour
{
    public int islandDimensions = 4;
    public Material[,] Grid { get; private set; }
    //Should always be within the grid 
    public Vector2Int currentGridSpot { get; private set; } = Vector2Int.zero;
    [SerializeField] IslandRenderer islandRenderer;
    private void Start()
    {
        Grid = new Material[islandDimensions, islandDimensions];
        islandRenderer.RenderIsland();
    }


    
    //Helpers
    private bool IsEmpty(Vector2Int target)
    {
        //Returns if the location has a Material
        //Garbage Material will return False
        return Grid[target[0], target[1]] == null;
    }
    private bool OnGrid(Vector2Int target)
    {
        //Returns if the locaiton is on the Grid
        return 0 <= target[0] && target[0] < islandDimensions && 
            0 <= target[1] && target[1] < islandDimensions;
    }

   

    //Main Functions
    public bool PlaceMaterial(Material mat)
    {
        //Returning false means unable to place the material
        if (!IsEmpty(currentGridSpot))
        {
            Debug.LogWarning("Trying to place on occupied spot");
            return false;
        }
        Grid[currentGridSpot[0], currentGridSpot[1]] = mat;
        islandRenderer.UpdateSpotMaterial(currentGridSpot);
        return true;

    }
    public bool MoveCurrentGridSpot(Vector2Int target)
    {
        //Returning false means unable to move to that grid spot
        if (!OnGrid(target))
        {
            Debug.LogWarning("Trying to move off the grid");
            return false;
        }
        Vector2Int previousSpot = currentGridSpot;
        currentGridSpot = target;
        islandRenderer.UpdateSpotSelector(previousSpot);
        islandRenderer.UpdateSpotSelector(currentGridSpot);
        return true;


    }
    /*
    private Material upcomingMaterial  = null;
    public Material UpcomingMaterial
    {
        get
        {
            if (upcomingMaterial == null)
                upcomingMaterial = matGenerator.GetNextMaterial();
            return upcomingMaterial;
        }
        set
        {
            upcomingMaterial = value;
        }
    }

    /*public GridSpot[,] Grid { 
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
                    newGridSpotObj.transform.SetParent(gridSpotsObj.transform, false);
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

 */
}




