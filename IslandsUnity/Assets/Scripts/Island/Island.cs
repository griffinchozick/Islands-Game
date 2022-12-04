using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MVC Model for IslandController
public class Island : MonoBehaviour
{
    public int islandDimensions = 5;
    public Placeable[,] Grid { get; private set; }
   // public bool[,] DefenseGrid;
    //Should always be within the grid 
    //public Vector2Int currentGridSpot { get; private set; } = Vector2Int.zero;
    [SerializeField] IslandRenderer islandRenderer;
    //Delete below once pooler implemented
    [SerializeField] GameObject trashPrefab;

    private int trashSpots = 0;
    private int objSpots = 0;
    public int totalTakenUpSpots { get { return trashSpots + objSpots; } }

    private void Start()
    {
        Grid = new Placeable[islandDimensions, islandDimensions];
       // DefenseGrid = new bool[islandDimensions, islandDimensions];
    }


    #region Helpers    
    public bool IsEmpty(Vector2Int target)
    {
        //Returns if the location has a Material
        //Garbage Material will return False
        return Grid[target[0], target[1]] == null;
    }
    public bool OnGrid(Vector2Int target)
    {
        //Returns if the locaiton is on the Grid
        return 0 <= target[0] && target[0] < islandDimensions && 
            0 <= target[1] && target[1] < islandDimensions;
    }
    public Placeable AtGrid(Vector2Int target)
    {
        return Grid[target[0], target[1]];
    }
    #endregion



    //Main Functions
    public bool CanPlaceObject(Vector2Int location)
    {
        if (!OnGrid(location))
        {
            Debug.LogWarning("Spot not on grid");
            return false;
        }
        else if (!IsEmpty(location))
        {
            return false;
        }
        return true;
    }

    public void AutoPlace(Placeable obj)
    {
        Vector2Int location = new Vector2Int();
        for (int j = 4; j >= 0; j--)
        {
            for (int i = 4; i >= 0 ; i--)
            {
                location.x = i;
                location.y = j;
                if (CanPlaceObject(location))
                {
                    //Debug.Log("place");
                    PlaceObject(obj, location);
                    return;
                }
            }
        }
    }

    public void PlaceObject(Placeable obj, Vector2Int location)
    {
        Grid[location[0], location[1]] = obj;
        islandRenderer.AddSpotPlaceable(location, obj);
        obj.location = location;
        objSpots++;
    }
    public void RemoveObject(Vector2Int location)
    {
        if (IsEmpty(location))
            Debug.Log("There was no item at the location");
        else
        {
            islandRenderer.RemoveSpotPlaceable(Grid[location[0], location[1]]);
            Grid[location[0], location[1]] = null;
            objSpots--;
        }
    }

    public bool CanTakeDamage(Vector2Int location)
    {
        if (AtGrid(location) is Trash)
            Debug.LogWarning("Spot already destroyed (is trash)");
        return !(AtGrid(location) is Trash);
    }
    public void TakeDamage(Vector2Int location)
    {
        if (IsEmpty(location))
        {
            Trash trash = Instantiate(trashPrefab).GetComponent<Trash>();
            PlaceObject(trash, location);
            trashSpots++;
        }
        else
        {
            RemoveObject(location);
        }
    }

    public void TakeDamage(List<Vector2Int> locations)
    {
        foreach (var location in locations)
            TakeDamage(location);
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




