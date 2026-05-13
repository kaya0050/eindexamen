using UnityEngine;
using UnityEngine.SceneManagement;

public class testerscript : MonoBehaviour
{
    manager manager;
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
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("test");
            if (manager != null)
            {
                manager.inMinigame = false;
            }
            
        }
        
        
    }
}
