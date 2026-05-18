using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;
using static Unity.VisualScripting.Metadata;

public class playermanager : MonoBehaviour
{
    public EventSystem eventSystem;
    public GameObject[] buttonsInCanvas;
    public Canvas canvas;
    public PlayerInput playerInput;
    public InputSystemUIInputModule uiModule;

    public int points = 0;
    manager manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        canvas.enabled = true;
        if (GameObject.Find("manager").GetComponent<manager>() != null)
        {
            manager = GameObject.Find("manager").GetComponent<manager>();
            manager.currentPlayer = gameObject;
        }

        manager.players.Add(gameObject);
        DontDestroyOnLoad(gameObject);
        uiModule = FindFirstObjectByType<InputSystemUIInputModule>();

        playerInput.uiInputModule = uiModule;
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();

        


        buttonsInCanvas = GameObject.FindGameObjectsWithTag("button");

        eventSystem.SetSelectedGameObject(buttonsInCanvas[0].gameObject);
        Debug.Log(eventSystem.currentSelectedGameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
