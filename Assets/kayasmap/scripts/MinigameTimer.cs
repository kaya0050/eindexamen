using TMPro;
using UnityEngine;

public class MinigameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timer = 180f;

    void Update()
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timer -= Time.deltaTime;
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
