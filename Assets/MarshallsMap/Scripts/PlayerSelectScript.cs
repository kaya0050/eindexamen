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

        // Preview modellen in menu
        public GameObject[] characterModels;
        public GameObject[] characterModelsTrue;
        [HideInInspector]
        public int currentCharacter;

        [HideInInspector]
        public bool ready;

        // Het echte gekozen prefab
        [HideInInspector]
        public GameObject selectedCharacter;

        // Geinstantieerde speler
        [HideInInspector]
        public GameObject spawnedCharacter;

        public TextMeshProUGUI readyText;
        public TextMeshProUGUI joinText;

        public Button readyButton;
        public Button nextButton;
        public Button previousButton;
    }

    public PlayerSlot[] players;

    public int currentPlayerAmount;
    public manager manager;

    public GameObject startButton;

    void Update()
    {
        currentPlayerAmount = manager.players.Count;
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

            players[i].joinText.gameObject.SetActive(!active);
            players[i].readyButton.gameObject.SetActive(active);

            if (active)
            {
                ShowCharacter(i);
            }
            else
            {
                HideAllCharacters(i);
            }
        }

        startButton.SetActive(allReady);
    }

    public void NextCharacter(int playerIndex)
    {
        if (players[playerIndex].ready)
            return;

        players[playerIndex].currentCharacter++;

        if (players[playerIndex].currentCharacter >= players[playerIndex].characterModels.Length)
        {
            players[playerIndex].currentCharacter = 0;
        }

        ShowCharacter(playerIndex);
    }

    public void PreviousCharacter(int playerIndex)
    {
        if (players[playerIndex].ready)
            return;

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
        PlayerSlot player = players[playerIndex];

        player.ready = !player.ready;

        if (player.ready)
        {
            player.readyText.text = "Ready";

            player.nextButton.gameObject.SetActive(false);
            player.previousButton.gameObject.SetActive(false);

            // gekozen prefab opslaan
            player.selectedCharacter =
                player.characterModelsTrue[player.currentCharacter];

            // oude verwijderen indien nodig
            if (player.spawnedCharacter != null)
            {
                Destroy(player.spawnedCharacter);
            }

            // speler model spawnen
            Instantiate(
                player.selectedCharacter,
                manager.players[playerIndex].transform
            );
        }
        else
        {
            player.readyText.text = "Not Ready";

            player.nextButton.gameObject.SetActive(true);
            player.previousButton.gameObject.SetActive(true);

            // spawned model verwijderen
            if (player.spawnedCharacter != null)
            {
                Destroy(player.spawnedCharacter);
            }
        }
    }

    void ShowCharacter(int playerIndex)
    {
        HideAllCharacters(playerIndex);

        players[playerIndex]
            .characterModels[players[playerIndex].currentCharacter]
            .SetActive(true);
    }

    void HideAllCharacters(int playerIndex)
    {
        for (int i = 0; i < players[playerIndex].characterModels.Length; i++)
        {
            players[playerIndex].characterModels[i].SetActive(false);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("test");
    }
}