using TMPro;
using UnityEngine;

public class UITurn : MonoBehaviour
{
    public TextMeshProUGUI turntext;
    public manager manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameObject.FindAnyObjectByType<manager>();
    }

    // Update is called once per frame
    void Update()
    {
        turntext.text = "player: " + (manager.currentPlayerTurn + 1).ToString() + "turn";
    }
}
