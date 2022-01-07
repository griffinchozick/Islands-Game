using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MVC View for IslandController
public class GridSelector : MonoBehaviour
{
    GridSpot highlightedSpot = null;
    public void SelectMoveSpot(GridSpot target)
    {
        if(highlightedSpot != null) { highlightedSpot.ToggleSpotSelector(); }
        target.ToggleSpotSelector();
        highlightedSpot = target;
    }


}
