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
        //Bepaalt startpositie van speler op basis van playerIndex.
        baseX = GetSpawnX(playerIndex);

        Vector3 pos = transform.position;
        pos.x = baseX;
        transform.position = pos;
    }

    float GetSpawnX(int id)
    {
        //Geeft elke speler een vaste start baan.
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
        //Stop beweging als de race niet actief is.
        if (!isRacing) return;

        //voorwaarts bewegen.
        Vector3 move = Vector3.forward * speed;

        //Berekent gewenste baan (links/midden/rechts).
        float targetX = baseX + (currentLane - 1) * laneDistance;

        //soepele beweging richting een andere baan.
        float deltaX = targetX - transform.position.x;
        move.x = deltaX / Time.deltaTime;

        //Beweeg speler met CharacterController.
        characterController.Move(move * Time.deltaTime);
    }

    public void OnMove(InputValue value)
    {
        //Input voor het verwisselen van baan.
        Vector2 input = value.Get<Vector2>();

        //Voorkomt te snelle baan wisselingen.
        if (Time.time < nextSwitchTime) return;

        //Ga naar de rechter baan.
        if (input.x > 0.5f)
        {
            currentLane = Mathf.Min(currentLane + 1, 2);
            nextSwitchTime = Time.time + laneSwitchCooldown;
        }
        //Ga naar de linker baan.
        else if (input.x < -0.5f)
        {
            currentLane = Mathf.Max(currentLane - 1, 0);
            nextSwitchTime = Time.time + laneSwitchCooldown;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Stop race bij finish of geraakte obstakel.
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