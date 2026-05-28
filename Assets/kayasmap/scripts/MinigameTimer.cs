using TMPro;
using UnityEngine;

public class MinigameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timer = 180f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timer -= Time.deltaTime;
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
