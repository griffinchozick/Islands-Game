using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Updates Sprites to match island data
public class IslandRenderer : MonoBehaviour
{    
    public SpriteRenderer[] spotRenderers;
    public GameObject placeableObjectsContainer;


    private int Index(Vector2Int location)
    {
        //Converts vector2 Int to index
        return location[0] + (location[1] * 5); 
    }

    public void AddSpotPlaceable(Vector2Int location, Placeable obj)
    {
        if (obj is Trash)
        {
            spotRenderers[Index(location)].enabled = false;
        }
        else
        {
            obj.transform.parent = placeableObjectsContainer.transform;
            obj.transform.localPosition = new Vector3(location.x, location.y, 0);
        }
    }
    public void RemoveSpotPlaceable(Placeable obj)
    {
        //Add logic to remove trash at a spot
        Destroy(obj.gameObject);
    }
}
