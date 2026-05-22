using UnityEngine;

public class PlayerScriptMinigame3 : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;

    public int health = 2;

    void Start()
    {
        health = 2;
    }

    void Update()
    {
        if (health <= 0)
        {
            GetPlayerOffScreen();
        }
    }

    public void GetPlayerOffScreen()
    {

    }
}
