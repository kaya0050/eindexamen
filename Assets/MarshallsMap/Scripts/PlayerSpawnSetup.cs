using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnSetup : MonoBehaviour
{
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        int index = playerInput.playerIndex;

        var mover = playerInput.GetComponent<RaceMovement>();
        mover.playerIndex = index;
    }
}