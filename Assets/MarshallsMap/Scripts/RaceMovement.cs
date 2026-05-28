using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class RaceMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float laneDistance = 3f;
    public float laneChangeSpeed = 10f;

    public int currentLane = 1;

    public bool isRacing = false;
    public bool isPlayer = false;

    public float gravity = -20f;
    private float verticalVelocity;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!isRacing) return;

        Vector3 move = Vector3.zero;

        move += HandleForward();
        move += HandleLane();
        move += HandleGravity();

        controller.Move(move * Time.deltaTime);
    }

    Vector3 HandleForward()
    {
        return transform.forward * moveSpeed;
    }

    Vector3 HandleLane()
    {
        Vector3 targetPosition = transform.position;
        targetPosition.x = (currentLane - 1) * laneDistance;

        Vector3 diff = targetPosition - transform.position;
        diff.y = 0;

        return diff * laneChangeSpeed;
    }

    Vector3 HandleGravity()
    {
        if (controller.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        return Vector3.up * verticalVelocity;
    }

    public void MoveLeft()
    {
        if (!isRacing) return;

        currentLane = Mathf.Max(0, currentLane - 1);
    }

    public void MoveRight()
    {
        if (!isRacing) return;

        currentLane = Mathf.Min(2, currentLane + 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            FinishRace();
        }
    }

    void FinishRace()
    {
        if (!isRacing) return;

        isRacing = false;
        RaceManager.instance.RegisterFinish(this);
    }
}