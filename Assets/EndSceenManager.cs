using System;
using System.IO;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class EndSceenManager : MonoBehaviour
{
    manager manager;
    public TextMeshProUGUI scoretext;
    [Serializable]
    public class Stats
    {
        public int points;
        public int playerindex;
    }

    Stats score = new Stats();
    Stats scorecompare = new Stats();
    string savePath;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        savePath = Path.Combine(Application.persistentDataPath, "score.json");
        manager = GameObject.FindAnyObjectByType<manager>();
        LoadStats();
        SaveStats();

    }
    public void SaveStats()
    {
        playermanager bestPlayer = null;

        foreach (var item in manager.players)
        {
            playermanager player = item.GetComponent<playermanager>();

            if (player.points > scorecompare.points)
            {
                if (bestPlayer == null || player.points > bestPlayer.points)
                {
                    bestPlayer = player;
                }
            }
        }

        if (bestPlayer != null)
        {
            score.points = bestPlayer.points;
            score.playerindex = bestPlayer.index;

            string json = JsonUtility.ToJson(score, true);
            File.WriteAllText(savePath, json);

            Debug.Log("highscore earned and saved to: " + savePath);
        }
        else
        {
            Debug.Log("no highscore earned");
        }
    }

    public void LoadStats()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            score = JsonUtility.FromJson<Stats>(json);
            scorecompare = JsonUtility.FromJson<Stats>(json);
            Debug.Log("Loaded!");
        }
    }
    // Update is called once per frame
    void Update()
    {
        scoretext.text = "hi score: " + score.points.ToString();
    }
}
