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

        public GameObject[] characterModels;      //UI previews van de characters.
        public GameObject[] characterModelsTrue;  //prefabs van de characters.

        public GameObject selectedCharacter;
        public GameObject spawnedCharacter;

        public int currentCharacter;
        public bool ready;

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
        //Checkt elke frame hoeveel spelers actief zijn en of iedereen ready is.
        currentPlayerAmount = manager.players.Count;

        bool allReady = currentPlayerAmount > 1;

        for (int i = 0; i < currentPlayerAmount; i++)
        {
            if (!players[i].ready)
                allReady = false;
        }

        //Update de UI per speler (join/ready status + character preview).
        for (int i = 0; i < players.Length; i++)
        {
            bool active = i < currentPlayerAmount;

            players[i].joinText.gameObject.SetActive(!active);
            players[i].readyButton.gameObject.SetActive(active);

            if (active)
                ShowCharacter(i);
            else
                HideAllCharacters(i);
        }

        //Start knop wordt alleen actief als iedereen ready is.
        startButton.SetActive(allReady);
    }

    public void NextCharacter(int playerIndex)
    {
        //Gaat naar het volgende character in de lijst.
        if (players[playerIndex].ready) return;

        players[playerIndex].currentCharacter++;

        if (players[playerIndex].currentCharacter >= players[playerIndex].characterModels.Length)
            players[playerIndex].currentCharacter = 0;

        ShowCharacter(playerIndex);
    }

    public void PreviousCharacter(int playerIndex)
    {
        //Gaat naar het vorige character in de lijst.
        if (players[playerIndex].ready) return;

        players[playerIndex].currentCharacter--;

        if (players[playerIndex].currentCharacter < 0)
            players[playerIndex].currentCharacter = players[playerIndex].characterModels.Length - 1;

        ShowCharacter(playerIndex);
    }

    public void ToggleReady(int playerIndex)
    {
        //Zet speler op ready of not ready en spawnt of verwijdert de character.
        PlayerSlot player = players[playerIndex];

        player.ready = !player.ready;

        if (player.ready)
        {
            //Speler heeft keuze bevestigd.
            player.readyText.text = "Ready";

            player.nextButton.gameObject.SetActive(false);
            player.previousButton.gameObject.SetActive(false);

            player.selectedCharacter =
                player.characterModelsTrue[player.currentCharacter];

            if (player.spawnedCharacter != null)
                Destroy(player.spawnedCharacter);

            //Spawn de gekozen character in de game.
            Instantiate(
                player.selectedCharacter,
                manager.players[playerIndex].transform
            );
        }
        else
        {
            //Speler gaat terug naar character select.
            player.readyText.text = "Not Ready";

            player.nextButton.gameObject.SetActive(true);
            player.previousButton.gameObject.SetActive(true);

            if (player.spawnedCharacter != null)
                Destroy(player.spawnedCharacter);
        }
    }

    void ShowCharacter(int playerIndex)
    {
        //Laat alleen het geselecteerde character zien in de UI.
        HideAllCharacters(playerIndex);

        players[playerIndex]
            .characterModels[players[playerIndex].currentCharacter]
            .SetActive(true);
    }

    void HideAllCharacters(int playerIndex)
    {
        //Verbergt alle character previews van deze speler.
        for (int i = 0; i < players[playerIndex].characterModels.Length; i++)
            players[playerIndex].characterModels[i].SetActive(false);
    }

    public void StartGame()
    {
        //Start de game scene zodra iedereen ready is.
        SceneManager.LoadScene("test");
    }
}