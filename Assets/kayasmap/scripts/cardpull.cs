using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Linq;

public class CardCarousel : MonoBehaviour
{
    public List<cardscript> cards;
    public InputActionReference moveAction;
    public InputActionReference selectAction;

    private int selectedIndex = 0;
    private Vector2 input;

    void OnEnable()
    {
        moveAction.action.Enable();
        selectAction.action.Enable();
    }

    void OnDisable()
    {
        moveAction.action.Disable();
        selectAction.action.Disable();
    }

    void Update()
    {
        cards = FindObjectsByType<cardscript>(FindObjectsSortMode.None).ToList<cardscript>();
        HandleInput();
        UpdateHighlight();
    }

    void HandleInput()
    {
        input = moveAction.action.ReadValue<Vector2>();

        // -> naar rechts
        if (input.x > 0.5f)
        {
            selectedIndex = (selectedIndex + 1) % cards.Count;
        }
        // <- naar links
        else if (input.x < -0.5f)
        {
            selectedIndex--;
            if (selectedIndex < 0) selectedIndex = cards.Count - 1;
        }

        //use card
        if (selectAction.action.WasPressedThisFrame())
        {
            cards[selectedIndex].UseCard();
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