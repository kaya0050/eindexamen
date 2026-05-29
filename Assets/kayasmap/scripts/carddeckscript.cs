using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CardDeckScript : MonoBehaviour
{
    public Manager manager;
    public List<Transform> cardsPositions = new List<Transform>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameObject.Find("manager").GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.current != null && Gamepad.current.startButton.wasPressedThisFrame || Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            DealCards();
        }
    }

    void DealCards()
    {
        //shufflecards
        for (int i = 0; i < cardsPositions.Count; i++)
        {
            int randomIndex = Random.Range(i, cardsPositions.Count);

            Transform temp = cardsPositions[i];
            cardsPositions[i] = cardsPositions[randomIndex];
            cardsPositions[randomIndex] = temp;
        }

        for (int i = 0; i < manager.cards.Count; i++)
        {
            manager.cards[i].transform.position = cardsPositions[i].position;
            cardscript cardscript = manager.cards[i].GetComponent<cardscript>();
            cardscript.startPos = cardsPositions[i].position;
        }
    }
}
