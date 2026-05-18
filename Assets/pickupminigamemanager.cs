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
        Timer--;
        if (Timer < 0)
        {
            SceneManager.LoadScene("test");

            if (manager != null)
            {
                manager.inMinigame = false;
            }
        }
        
    }
}
