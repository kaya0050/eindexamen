using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelectScript : MonoBehaviour
{
    [System.Serializable]
    public class PlayerSlot
    {
        public GameObject playerPanel;

        public GameObject[] characterModels;

        [HideInInspector]
        public int currentCharacter;

        [HideInInspector]
        public bool ready;
    }

    public PlayerSlot[] players;

    public int currentPlayerAmount = 2;

    public GameObject startButton;

    void Start()
    {
        for (int i = 0; i < players.Length; i++)
        {
            bool active = i < currentPlayerAmount;

            players[i].playerPanel.SetActive(active);

            if (active)
            {
                ShowCharacter(i);
            }
        }
    }

    void Update()
    {
        bool allReady = true;

        for (int i = 0; i < currentPlayerAmount; i++)
        {
            if (!players[i].ready)
            {
                allReady = false;
            }
        }

        startButton.SetActive(allReady);
    }

    public void NextCharacter(int playerIndex)
    {
        players[playerIndex].currentCharacter++;

        if (players[playerIndex].currentCharacter >= players[playerIndex].characterModels.Length)
        {
            players[playerIndex].currentCharacter = 0;
        }

        ShowCharacter(playerIndex);
    }

    public void PreviousCharacter(int playerIndex)
    {
        players[playerIndex].currentCharacter--;

        if (players[playerIndex].currentCharacter < 0)
        {
            players[playerIndex].currentCharacter =
                players[playerIndex].characterModels.Length - 1;
        }

        ShowCharacter(playerIndex);
    }

    public void ToggleReady(int playerIndex)
    {
        players[playerIndex].ready = !players[playerIndex].ready;
    }

    void ShowCharacter(int playerIndex)
    {
        for (int i = 0; i < players[playerIndex].characterModels.Length; i++)
        {
            players[playerIndex].characterModels[i].SetActive(false);
        }

        players[playerIndex].characterModels[players[playerIndex].currentCharacter].SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}