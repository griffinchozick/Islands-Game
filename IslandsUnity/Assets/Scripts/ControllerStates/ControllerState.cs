using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControllerState 
{
    
    public abstract bool MainAction(IslandController iController);
    //If false it means the mainAction failed
    public abstract void EnterState(IslandController iController);
}
