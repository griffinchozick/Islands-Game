using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material 
{
    public enum MatType
    {
        Trash,
        Red,
        Blue,
        Green,
    }
    public MatType type;
    public Material(MatType _type)
    {
        type = _type;
    }




    public Material[] Neighbors;

}
