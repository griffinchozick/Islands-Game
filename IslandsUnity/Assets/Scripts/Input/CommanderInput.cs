using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class CommanderInput : MonoBehaviour
{
    [SerializeField] IslandController islandController;

    public void SetIslandController(IslandController _islandController)
    {
        Debug.Log("B");

        islandController = _islandController;
    }

    public void OnMove(CallbackContext context)
    {
        if (!context.performed) { return; }
        if( islandController == null)
        {
            Debug.Log("Moving");
            Debug.Log(name);
            return;
        }

        Debug.Log("Context: " + context);
        Debug.Log("islandController: " + islandController);
        islandController.MoveSelectorDirection(Vector2Int.CeilToInt(context.ReadValue<Vector2>()));
    }

    public void OnFire(CallbackContext context)
    {
        if (!context.performed) { return; }
        if (islandController == null)
        {
            Debug.Log("Moving");
            Debug.Log(name);
            return;
        }
        Debug.Log("Firing");
        Debug.Log("Context: " + context);
        Debug.Log("islandController: " + islandController);
        islandController.MainAction();
    }

    public void OnAltFire(CallbackContext context)
    {
        if (!context.performed) { return; }
        //islandController.TryConstructBuilding();
    }

}
