using UnityEngine;

public class RaceCameraMovement : MonoBehaviour
{
    public float startTimer = 3f;
    public float moveSpeed = 10f;

    public bool stopMoving = false;

    void Update()
    {
        if (startTimer > 0)
        {
            startTimer -= Time.deltaTime;
        }

        if (startTimer <= 0 && !stopMoving)
        {
            MoveCamera();
        }
    }

    void MoveCamera()
    {
        Vector3 moveDirection = Vector3.forward;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        transform.forward = moveDirection;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            stopMoving = true;
        }
    }
}