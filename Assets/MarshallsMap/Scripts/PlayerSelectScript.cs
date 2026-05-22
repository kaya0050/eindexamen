using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

        public TextMeshProUGUI readyText;
        public TextMeshProUGUI joinText;

        public Button readyButton;
        public Button nextButton;
        public Button previousButton;
    }

    public PlayerSlot[] players;

    public int currentPlayerAmount;

    public GameObject startButton;

    void Update()
    {
        bool allReady = false;

        if (currentPlayerAmount > 1)
        {
            allReady = true;

            for (int i = 0; i < currentPlayerAmount; i++)
            {
                if (!players[i].ready)
                {
                    allReady = false;
                }
            }
        }

        for (int i = 0; i < players.Length; i++)
        {
            bool active = i < currentPlayerAmount;

            for (int j = 0; j < players[i].characterModels.Length; j++)
            {
                players[i].characterModels[j].SetActive(active);
                players[i].joinText.gameObject.SetActive(!active);
                players[i].readyButton.gameObject.SetActive(active);
            }

            if (active)
            {
                ShowCharacter(i);
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

        if (players[playerIndex].ready)
        {
            players[playerIndex].readyText.text = "Ready";
            players[playerIndex].nextButton.gameObject.SetActive(false);
            players[playerIndex].previousButton.gameObject.SetActive(false);
        } else
        {
            players[playerIndex].readyText.text = "Not ready";
            players[playerIndex].nextButton.gameObject.SetActive(true);
            players[playerIndex].previousButton.gameObject.SetActive(true);
        }
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
        SceneManager.LoadScene("test");
    }
}