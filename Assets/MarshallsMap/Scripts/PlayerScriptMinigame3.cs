using UnityEngine;

public class PlayerScriptMinigame3 : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;

    public int health = 2;

    public bool isAlive = true;

    public Transform deathPosition;

    void Start()
    {
        health = 2;

        if (deathPosition == null)
        {
            GameObject dp = GameObject.Find("DeathPosition");
            if (dp != null)
            {
                deathPosition = dp.transform;
            }
            else
            {
                Debug.LogError("DeathPosition niet gevonden in de scene!");
            }
        }
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
        isAlive = false;
        transform.position = deathPosition.position;
    }
}
