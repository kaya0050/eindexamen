using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    public float speed = 5f;

    Vector2 moveInput;
    manager manager;

    void Start()
    {
        if (GameObject.Find("manager").GetComponent<manager>() != null)
        {
            manager = GameObject.Find("manager").GetComponent<manager>();
        }
        manager.players.Add(gameObject);
        DontDestroyOnLoad(gameObject);
        characterController = GetComponent<CharacterController>();
    }

    // Deze functie wordt automatisch aangeroepen door Input System
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("a");
        }

        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y);

        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }

        characterController.Move(movement * speed * Time.deltaTime);
    }
}