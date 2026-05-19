using UnityEngine;
using UnityEngine.SceneManagement;

public class pickupminigamemanager : MonoBehaviour
{
    manager manager;
    public int Timer = 9000;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameObject.Find("manager").GetComponent<manager>() != null)
        {
            manager = GameObject.Find("manager").GetComponent<manager>();
            manager.inMinigame = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //een functie om te wisselen naar score scherm
        Timer--;
        if (Timer < 0)
        {
            SceneManager.LoadScene("scorescene");

            if (manager != null)
            {
                manager.inMinigame = false;
            }
        }
        
    }
}
