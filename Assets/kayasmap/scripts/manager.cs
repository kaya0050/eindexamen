using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{
    public bool inMinigame = false;
    public List<GameObject> cards = new List<GameObject>();
    public List<GameObject> players = new List<GameObject>();
    public GameObject currentPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (cards.Count <= 0 && !inMinigame)
        {
            Debug.Log("game end");
            SceneManager.LoadScene("endscene");

        }
        if (inMinigame)
        {
            for (int i = 0; i < players.Count; i++)
            {
                players[i].SetActive(true);
            }
            for (int i = 0; i < cards.Count; i++)
            {
                cards[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < players.Count; i++)
            {
                players[i].SetActive(false);
               
            }
            for (int i = 0; i < cards.Count; i++)
            {
                cards[i].SetActive(true);
            }
        }
    }

}
