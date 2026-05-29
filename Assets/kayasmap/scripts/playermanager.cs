using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;


public class PlayerManager : MonoBehaviour
{
    public int index = 0;
    public EventSystem eventSystem;
    public GameObject[] buttonsInCanvas;
    public Canvas canvas;
    public PlayerInput playerInput;
    public InputSystemUIInputModule uiModule;

    public int points = 0;
    public int winTimes;
    Manager manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        buttonsInCanvas = GameObject.FindGameObjectsWithTag("button");
        manager = GameObject.Find("manager").GetComponent<manager>();
        uiModule = FindFirstObjectByType<InputSystemUIInputModule>();

        manager.currentPlayer = gameObject;
        canvas.enabled = true;
        index = manager.players.Count;
        manager.players.Add(gameObject);
        playerInput.uiInputModule = uiModule;
        eventSystem.SetSelectedGameObject(buttonsInCanvas[0].gameObject);
    }
}
