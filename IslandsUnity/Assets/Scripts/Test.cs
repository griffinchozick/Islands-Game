using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public string addOn = "";
    public void OnFire()
    {
        Debug.Log(name + " Fire " + addOn);
    }
}
