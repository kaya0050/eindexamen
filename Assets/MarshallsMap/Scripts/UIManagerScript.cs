using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour
{
    public float timer = 180f;
    public float startTimer = 3f;

    public int alivePlayers;

    public FireBallSpawner fireBallSpawner;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI startTimerText;

    void Update()
    {
        HandleStartTimer();

        HandleGameTimer();

        CountAlivePlayers();

        UpdateUI();
    }

    void HandleStartTimer()
    {
        startTimer -= Time.deltaTime;

        if (startTimer <= 0)
        {
            startTimerText.gameObject.SetActive(false);
            fireBallSpawner.gameStarted = true;
        }
    }

    void HandleGameTimer()
    {
        if (fireBallSpawner.gameStarted && timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                SceneManager.LoadScene("scorescene");
            }
        }
    }

    void CountAlivePlayers()
    {
        alivePlayers = 0;

        PlayerScriptMinigame3[] players =
            FindObjectsByType<PlayerScriptMinigame3>(FindObjectsSortMode.None);

        foreach (PlayerScriptMinigame3 player in players)
        {
            if (player.isAlive)
            {
                alivePlayers++;
            }
        }
    }

    void UpdateUI()
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (startTimer > 0)
        {
            startTimerText.text =
                Mathf.CeilToInt(startTimer).ToString();
        }
    }
}