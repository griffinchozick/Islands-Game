using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class InputIsland : MonoBehaviour
{
    [SerializeField] GridSelector gridSelector;
    public void OnMove(CallbackContext context)
    {
        if (!context.started) { return; }
        gridSelector.UpdateGridSpot(context.ReadValue<Vector2>());
    }

}
