using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Linq;

public class CardPull : MonoBehaviour
{

    //public int playerIndex; 
    public manager manager;
    public GameObject currentPlayer;

    public List<cardscript> cards;

    public PlayerInput playerInput;



    private int selectedIndex = 0;
    private Vector2 input;
    private bool canMove = true;


    void Update()
    {
        cards = FindObjectsByType<cardscript>(FindObjectsSortMode.None).ToList();
        HandleInput();
        UpdateHighlight();

    }

    void HandleInput()
    {
        Debug.Log("Players: " + manager.players.Count);
        Debug.Log("Turn: " + manager.currentPlayerTurn);
        Debug.Log("Current: " + manager.players[manager.currentPlayerTurn].name);
        if (manager.players == null || manager.players.Count == 0)
            return;

        if (manager.currentPlayerTurn >= manager.players.Count)
            return;

        GameObject currentPlayer = manager.players[manager.currentPlayerTurn];

        PlayerInput playerInput = currentPlayer.GetComponent<PlayerInput>();

        if (playerInput == null)
            return;

        InputAction move = playerInput.actions["Move"];
        InputAction select = playerInput.actions["Select"];

        Vector2 input = move.ReadValue<Vector2>();

        if (Mathf.Abs(input.x) < 0.2f)
            canMove = true;

        if (canMove)
        {
            if (input.x > 0.5f)
            {
                selectedIndex = (selectedIndex + 1) % cards.Count;
                canMove = false;
            }
            else if (input.x < -0.5f)
            {
                selectedIndex--;

                if (selectedIndex < 0)
                    selectedIndex = cards.Count - 1;

                canMove = false;
            }
        }

        if (select.WasPressedThisFrame())
        {
            cards[selectedIndex].UseCard();
            manager.NextTurn();
        }
    }

    void UpdateHighlight()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            if (i == selectedIndex)
                cards[i].HighlightCard();
        }
    }
}