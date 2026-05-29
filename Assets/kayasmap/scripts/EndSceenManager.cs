using System;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [Serializable]
    public class Stats
    {
        public string playerName;
        public int points;
    }

    Stats score = new Stats();

    string savePath;
    public GameObject statsScreen;
    public GameObject highscoreScreen;
    public TextMeshProUGUI points;
    public TextMeshProUGUI playerStats;

    public TMP_InputField nameInput;
    manager manager;
    string textStats;
    playermanager playma;
    void Start()
    {
        manager = GameObject.FindAnyObjectByType<manager>();
        savePath = Path.Combine(Application.persistentDataPath, "save.json");
        playma = CheckhighScore();
        LoadStats();

        nameInput.text = score.playerName;

        Updatetext();
    }
    public void Statistics()
    {
        statsScreen.SetActive(!statsScreen.active);
    }
    public playermanager CheckhighScore()
    {
        playermanager bestPlayer = null;

        foreach (var item in manager.players)
        {
            playermanager player = item.GetComponent<playermanager>();

            if (bestPlayer == null || player.points > bestPlayer.points)
            {
                bestPlayer = player;
            }
        }

        if (bestPlayer.points > score.points)
        {
            highscoreScreen.SetActive(true);
            Debug.Log("new highscore.");
            return bestPlayer;
        }
        else
        {
            Debug.Log("no new highscore.");
            return bestPlayer;
        }
        
        
    }
    public void SaveHighscore()
    {
        score.playerName = nameInput.text;
        score.points = playma.points;

        string json = JsonUtility.ToJson(score, true);
        File.WriteAllText(savePath, json);

        Debug.Log("Saved to: " + savePath);
        LoadStats();

        Updatetext();
    }
    public void Updatetext()
    {
        points.text = "old highscore: " + score.playerName + " points: " + score.points;
        for (int i = 0; i < manager.players.Count; i++)
        {
            playermanager mana = manager.players[i].GetComponent<playermanager>();
            textStats += "player: " + (mana.index + 1) + "\n"
              + "wins: " + mana.winTimes + "\n"
              + "points: " + mana.points + "\n\n";
        }
        playerStats.text = textStats;
        
    }
    public void LoadStats()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);

            score = JsonUtility.FromJson<Stats>(json);

            Debug.Log("Loaded!");
        }
    }
}