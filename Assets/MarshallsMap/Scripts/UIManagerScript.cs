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
        //deze functie zorgt ervoor dat de start timer aftelt, verdwijnt en het spel begint.
        startTimer -= Time.deltaTime;

        if (startTimer <= 0)
        {
            startTimerText.gameObject.SetActive(false);
            fireBallSpawner.gameStarted = true;
        }
    }

    void HandleGameTimer()
    {
        //deze functie laat de tijd lopen voor de minigame en als de tijd om is eindigd hij de minigame.
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
        //deze functie controleert hoeveel spelers er in de minigame zijn zodat een ander script weet hoeveel spelers er in de minigame zit.
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
        //hier wordt de UI geupdate en de timers op de juiste wijze weergegeven
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