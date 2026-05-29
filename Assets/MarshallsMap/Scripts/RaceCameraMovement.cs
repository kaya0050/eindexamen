using UnityEngine;

public class RaceCameraMovement : MonoBehaviour
{
    public float startTimer = 3f;
    public float moveSpeed = 10f;

    public bool stopMoving = false;

    void Update()
    {
        //Wacht eerst voordat de camera beweegt.
        if (startTimer > 0)
        {
            startTimer -= Time.deltaTime;
        }

        //Zodra de countdown klaar is begint de camera te bewegen.
        if (startTimer <= 0 && !stopMoving)
        {
            MoveCamera();
        }
    }

    void MoveCamera()
    {
        //Laat de camera constant vooruit bewegen.
        Vector3 moveDirection = Vector3.forward;

        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        //Zorgt dat de camera altijd dezelfde richting op kijkt.
        transform.forward = moveDirection;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Stopt camera beweging wanneer finish wordt bereikt.
        if (other.CompareTag("Finish"))
        {
            stopMoving = true;
        }
    }
}