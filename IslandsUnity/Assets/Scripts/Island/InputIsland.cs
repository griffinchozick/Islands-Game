using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class InputIsland : MonoBehaviour
{
    [SerializeField] IslandController islandController;
    public void OnMove(CallbackContext context)
    {
        if (!context.performed) { return; }
        islandController.TryChangeGridSelector(Vector2Int.CeilToInt(context.ReadValue<Vector2>()));
    }

    public void OnFire(CallbackContext context)
    {
        if (!context.performed) { return; }
        islandController.TryPlaceMaterial();
    }

}
