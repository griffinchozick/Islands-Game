using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputAssigner : MonoBehaviour
{
    //Should only ever be length 2
    public IslandController[] controllers;
    //[SerializeField] GameObject playerInputPrefab;

    bool assignedFirstPlayer = false;
    public void Awake()
    {

        //PlayerInput input1 = PlayerInput.Instantiate(playerInputPrefab, pairWithDevice: Keyboard.current);
        //PlayerInput input2 = PlayerInput.Instantiate(playerInputPrefab, pairWithDevice: Keyboard.current);
        //input2.SwitchCurrentControlScheme("Keyboard2");
        //input1.GetComponent<IslandInput>().islandController = controllers[0];
        //input2.GetComponent<IslandInput>().islandController = controllers[1];

    }

    public void AssignInput(PlayerInput playerInput)
    {
        Debug.Log(playerInput.devices[0] + "Joined!");
        if (!assignedFirstPlayer)
        {
            /*Debug.Log("A");
            playerInput.gameObject.name = "Player1Input";
            playerInput.GetComponent<CommanderInput>().SetIslandController(controllers[0]);*/
            //playerInput.GetComponent<Test>
            assignedFirstPlayer = true;
        }
        else
        {
          /*  playerInput.gameObject.name = "Player2Input";
            playerInput.GetComponent<CommanderInput>().SetIslandController(controllers[1]);*/
        }
    }
}

