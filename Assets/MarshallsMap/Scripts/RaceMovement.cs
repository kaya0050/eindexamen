using UnityEngine;
using UnityEngine.InputSystem;

public class RaceMovement : MonoBehaviour
{
    public CharacterController characterController;

    public float speed = 5f;
    public float laneDistance = 2f;

    public bool isRacing = true;

    public int playerIndex;

    int currentLane = 1;
    float baseX;

    public float laneSwitchCooldown = 0.25f;
    float nextSwitchTime = 0f;

    void Start()
    {
        baseX = GetSpawnX(playerIndex);

        Vector3 pos = transform.position;
        pos.x = baseX;
        transform.position = pos;
    }

    float GetSpawnX(int id)
    {
        return id switch
        {
            0 => -15f,
            1 => -5f,
            2 => 5f,
            3 => 15f,
            _ => 0f
        };
    }

    void Update()
    {
        if (!isRacing) return;

        Vector3 move = Vector3.forward * speed;

        float targetX = baseX + (currentLane - 1) * laneDistance;

        float deltaX = targetX - transform.position.x;
        move.x = deltaX / Time.deltaTime;

        characterController.Move(move * Time.deltaTime);
    }

    public void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        if (Time.time < nextSwitchTime) return;

        if (input.x > 0.5f)
        {
            currentLane = Mathf.Min(currentLane + 1, 2);
            nextSwitchTime = Time.time + laneSwitchCooldown;
        }
        else if (input.x < -0.5f)
        {
            currentLane = Mathf.Max(currentLane - 1, 0);
            nextSwitchTime = Time.time + laneSwitchCooldown;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            isRacing = false;
        }

        if (other.CompareTag("Obstacle"))
        {
            isRacing = false;
        }
    }
}