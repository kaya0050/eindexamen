using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnSetup : MonoBehaviour
{
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        //dit pakt de playerinput en checkt hoeveel players er spawnen en geeft een index mee die gebruikt word in de race minigame.
        int index = playerInput.playerIndex;

        var mover = playerInput.GetComponent<RaceMovement>();
        mover.playerIndex = index;
    }
}