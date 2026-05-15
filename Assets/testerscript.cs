using UnityEngine;
using UnityEngine.InputSystem;
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
        if (Keyboard.current.escapeKey.wasPressedThisFrame ||
            (Gamepad.current != null && Gamepad.current.startButton.wasPressedThisFrame))
        {
            SceneManager.LoadScene("test");

            if (manager != null)
            {
                manager.inMinigame = false;
            }
        }


    }
}
