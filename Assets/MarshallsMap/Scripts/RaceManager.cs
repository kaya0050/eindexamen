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
        if (gameStarted)
        {
            timer -= Time.deltaTime;
        }

        UpdateUI();
        HandleStartTimer();
    }

    void HandleStartTimer()
    {
        startTimer -= Time.deltaTime;

        if (startTimer <= 0)
        {
            startTimerText.gameObject.SetActive(false);
            gameStarted = true;
        }
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
