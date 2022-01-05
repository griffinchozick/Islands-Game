using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class InputIsland : MonoBehaviour
{
    [SerializeField] GridSelector gridSelector;
    public void Move(CallbackContext context)
    {
        gridSelector.UpdateGridSpot(context.ReadValue<Vector2>());
    }

}
