using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class RaceManager : MonoBehaviour
{
    public static RaceManager instance;

    public bool gameStarted = false;
    public bool allFinished = false;

    public float startTimer = 3f;
    public float raceTimer = 180f;

    public List<RaceMovement> finishOrder = new List<RaceMovement>();

    public TextMeshProUGUI startTimerText;
    public TextMeshProUGUI timerText;

    public playermanager playerManager;

    private bool scoreGiven = false;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        HandleStartTimer();
        HandleRaceTimer();
        UpdateUI();

        //Als iedereen klaar is, geef score en ga naar score scene.
        if (allFinished && !scoreGiven)
        {
            scoreGiven = true;
            GiveScore();
            SceneManager.LoadScene("scorescene");
        }
    }

    void HandleStartTimer()
    {
        //Start countdown voordat race begint.
        if (gameStarted) return;

        startTimer -= Time.deltaTime;

        startTimerText.text = Mathf.CeilToInt(startTimer).ToString();

        //Start de race als timer op 0 komt.
        if (startTimer <= 0)
        {
            gameStarted = true;
            startTimerText.gameObject.SetActive(false);

            //Zet alle spelers in een "race mode".
            RaceMovement[] players = FindObjectsByType<RaceMovement>(FindObjectsSortMode.None);
            foreach (RaceMovement p in players)
            {
                p.isRacing = true;
            }
        }
    }

    void HandleRaceTimer()
    {
        //Alleen timer laten lopen tijdens race.
        if (!gameStarted || allFinished) return;

        raceTimer -= Time.deltaTime;

        //Race eindigt als timer op is of iedereen gefinished is.
        if (raceTimer <= 0)
        {
            allFinished = true;
        }

        if (AllPlayersFinished())
        {
            allFinished = true;
        }
    }

    bool AllPlayersFinished()
    {
        //Checkt of alle spelers gestopt zijn met racen.
        RaceMovement[] players = FindObjectsByType<RaceMovement>(FindObjectsSortMode.None);

        foreach (var p in players)
        {
            if (p.isRacing) return false;
        }

        return true;
    }

    void UpdateUI()
    {
        //Update race timer UI naar het juiste formaat.
        int minutes = Mathf.FloorToInt(raceTimer / 60);
        int seconds = Mathf.FloorToInt(raceTimer % 60);

        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    public void RegisterFinish(RaceMovement player)
    {
        //Voegt speler toe aan finish volgorde.
        if (!finishOrder.Contains(player))
        {
            finishOrder.Add(player);
        }
    }

    void GiveScore()
    {
        //Score systeem gebaseerd op finish positie.
        //(staat nu uitgeschakeld vanwege wat probleempjes)
        /*
        for (int i = 0; i < finishOrder.Count; i++)
        {
            int points = 0;

            switch (i)
            {
                case 0: points = 150; break;
                case 1: points = 100; break;
                case 2: points = 50; break;
                default: points = 10; break;
            }

            if (finishOrder[i].isPlayer)
            {
                playerManager.points += points;
            }
        }
        */
    }
}