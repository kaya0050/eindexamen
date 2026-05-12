using UnityEngine;
using UnityEngine.SceneManagement;

public class testerscript : MonoBehaviour
{
    manager manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameObject.Find("manager").GetComponent<manager>();
        manager.inMinigame = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("test");
            manager.inMinigame = false;
        }
    }
}
