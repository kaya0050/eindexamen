using Unity.Hierarchy;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;

    public float speed = 5f;
    public float gravity = -10;
    public float jumpHeight = 2f;

    Vector2 moveInput;
    float yVelocity;
    public AudioSource audioSource;
    public AudioClip jumpSound;

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    public void OnJump()
    {
        if (characterController.isGrounded)
        {
            audioSource.PlayOneShot(jumpSound, 1);
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
        //rotate
        if (movement.x != 0 || movement.z != 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(movement.x, 0, movement.z));
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
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