using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScriptMinigame3 : MonoBehaviour
{
    public int health = 2;
    public int earnedScore;

    public bool isAlive = true;
    public bool giveScore = true;
    public bool laatsteSpeler = false;

    public float endGameTimer = 3f;

    public Transform deathPosition;

    public UIManagerScript uiManager;
    public playermanager playerManager;

    void Start()
    {
        playerManager = GameObject.FindAnyObjectByType<playermanager>();

        health = 2;
    }

    void Update()
    {
        uiManager = GameObject.FindAnyObjectByType<UIManagerScript>();

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

        if (health == 0 && isAlive)
        {
            CheckEarnedScore();
            GetPlayerOffScreen();
        }

        if (laatsteSpeler)
        {
            endGameTimer -= Time.deltaTime;
        }

        if (endGameTimer <= 0)
        {
            SceneManager.LoadScene("scorescene");
        }
    }

    public void CheckEarnedScore()
    {
        if (giveScore)
        {
            switch (uiManager.alivePlayers)
            {
                case 4:
                    earnedScore = 0;
                    playerManager.points += earnedScore;
                    health = -1;
                    giveScore = false;
                    break;
                case 3:
                    earnedScore = 50;
                    playerManager.points += earnedScore;
                    health = -1;
                    giveScore = false;
                    break;
                case 2:
                    earnedScore = 100;
                    playerManager.points += earnedScore;
                    health = -1;
                    giveScore = false;
                    
                    break;
                case 1:
                    earnedScore = 150;
                    playerManager.points += earnedScore;
                    health = -1;
                    giveScore = false;
                    laatsteSpeler = true;
                    break;
            }
        }
    }

    public void GetPlayerOffScreen()
    {
        isAlive = false;
        transform.position = deathPosition.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FireBall"))
        {
            health--;
            Destroy(other.gameObject);
        }
    }
}
