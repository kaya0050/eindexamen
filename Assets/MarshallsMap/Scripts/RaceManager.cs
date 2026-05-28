using TMPro;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public bool gameStarted = false;

    public float startTimer = 3f;
    public float timer = 3f;

    public TextMeshProUGUI startTimerText;
    public TextMeshProUGUI timerText;

    void Start()
    {
        
    }

    void Update()
    {
        if (startTimer <= 0)
        {
            gameStarted = true;
        }

        if (gameStarted)
        {
            timer -= Time.deltaTime;
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (startTimer > 0)
        {
            startTimerText.text = Mathf.CeilToInt(startTimer).ToString();
        }
    }
}
