using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : MonoBehaviour
{
    public enum MatType
    {
        Red,
        Blue
    }

    public MatType Type;

    GameObject obj = null;
    public GameObject Obj { 
        get { 
            if(obj != null) return obj; 
            obj = gameObject;
            return obj;
        } 
        set { obj = value; }
    }
}
