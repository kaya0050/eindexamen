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
    public List<GameObject> buttons;
    public List<GameObject> buttonsInCanvas;
    public Canvas canvas;
    public PlayerInput playerInput;
    public InputSystemUIInputModule uiModule;

    public int points = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiModule = FindFirstObjectByType<InputSystemUIInputModule>();

        playerInput.uiInputModule = uiModule;
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        foreach (Transform child in transform)
        {
            buttons.Add(child.gameObject);
        }

        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        foreach (var item in buttons)
        {
            GameObject newb = Instantiate<GameObject>(item,canvas.transform);
            buttonsInCanvas.Add(newb);
        }
        eventSystem.SetSelectedGameObject(buttonsInCanvas[0].gameObject);
        Debug.Log(eventSystem.currentSelectedGameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
