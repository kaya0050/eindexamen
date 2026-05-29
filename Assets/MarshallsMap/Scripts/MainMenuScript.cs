using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject optionMenu;
    public GameObject statsMenu;
    public GameObject playerSelectMenu;
    public TextMeshProUGUI playercount;
    public manager manager;

    public void Update()
    {
        playercount.text = manager.players.Count.ToString();
    }
    public void OpenOptionsMenu()
    {
        //deze functie word aan een button gekoppeld zodat je het options menu kan openen.
        optionMenu.SetActive(true);
    }

    public void CloseOptionsMenu()
    {
        //deze functie word aan een button gekoppeld zodat je het options menu kan sluiten.
        optionMenu.SetActive(false);
    }

    public void OpenStatsMenu()
    {
        //deze functie word aan een button gekoppeld zodat je het stats menu kan openen.
        statsMenu.SetActive(true);
    }

    public void CloseStatsMenu()
    {
        //deze functie word aan een button gekoppeld zodat je het stats menu kan sluiten.
        statsMenu.SetActive(false);
    }

    public void OpenPlayerSelectMenu()
    {
        //deze functie word aan een button gekoppeld zodat je het player select menu kan openen.
        playerSelectMenu.SetActive(true);
    }

    public void ClosePlayerSelectMenu()
    {
        //deze functie word aan een button gekoppeld zodat je het player select menu kan sluiten.
        playerSelectMenu.SetActive(false);
    }
    public void CloseGame()
    {
        //deze functie word aan een button gekoppeld en sluit het spel af als deze button gebruikt word.
        Environment.Exit(0);
    }
}
