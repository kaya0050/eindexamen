using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour
{
    public float timer = 180f;

    public FireBallSpawner fireBallSpawner;

    public TextMeshProUGUI timerText;

    void Update()
    {
        if (fireBallSpawner.gameStarted && timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                SceneManager.LoadScene("scorescene");
            }
        }

        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
