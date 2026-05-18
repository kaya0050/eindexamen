using TMPro;
using UnityEngine;

public class UIManagerScript : MonoBehaviour
{
    public float timer = 180f;

    public FireBallSpawner fireBallSpawner;

    public TextMeshProUGUI timerText;

    public GameObject endScreen;

    void Update()
    {
        if (fireBallSpawner.gameStarted && timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                endScreen.SetActive(true);
            }
        }

        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
