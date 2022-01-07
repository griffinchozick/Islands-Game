using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MVC View for IslandController
public class GridSelector : MonoBehaviour
{
    public void SelectSpot(GridSpot target)
    {
        //float opacity = (alreadyHighlighted) ? 1f : 0f;
        //spriteRenderer.color = new Color(1f, 1f, 1f, opacity);
    }
}

//private GridSpot currentGridSpot;
//public GridSpot CurrentGridSpot
//{
//    get { return currentGridSpot; }
//    set
//    {
//        if (currentGridSpot != value)
//        {     
//            if (currentGridSpot != null) { currentGridSpot.Highlight(true); }
//            currentGridSpot = value;
//            currentGridSpot.Highlight(false);
//        }
//    }
//}