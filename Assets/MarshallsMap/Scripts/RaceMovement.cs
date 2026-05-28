using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class RaceMovement : MonoBehaviour
{
    public float moveSpeed = 10f;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 move = Vector3.zero;

        move += HandleForward();

        controller.Move(move * Time.deltaTime);
    }

    Vector3 HandleForward()
    {
        return transform.forward * moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}