using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 5f;
    public float gravity = -10;
    public float jumpHeight = 2f;

    Vector2 moveInput;
    float yVelocity;

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
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    public void OnJump()
    {
        if (characterController.isGrounded)
        {
            yVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    void Update()
    {
        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y);

        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }

        // gravity
        if (characterController.isGrounded && yVelocity < 0)
        {
            yVelocity = -2f;
        }

        yVelocity += gravity * Time.deltaTime;

        movement.y = yVelocity;

        characterController.Move(movement * speed * Time.deltaTime);
    }
}