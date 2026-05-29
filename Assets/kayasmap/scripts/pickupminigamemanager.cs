using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupMinigameManager : MonoBehaviour
{
    Manager manager;
    public MinigameTimer minigameTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameObject.Find("manager").GetComponent<Manager>() != null)
        {
            manager = GameObject.Find("manager").GetComponent<Manager>();
            manager.inMinigame = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //een functie om te wisselen naar score scherm

        if (minigameTimer.timer < 0)
        {
            SceneManager.LoadScene("scorescene");

            if (manager != null)
            {
                manager.inMinigame = false;
            }
        }
        
    }
}
