using TMPro;
using UnityEngine;

public class UITurn : MonoBehaviour
{
    public TextMeshProUGUI turnText;
    public manager manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameObject.FindAnyObjectByType<manager>();
    }

    // Update is called once per frame
    void Update()
    {
        turnText.text = "player: " + (manager.currentPlayerTurn + 1).ToString() + "turn";
    }
}
