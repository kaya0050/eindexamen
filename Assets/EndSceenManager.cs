using UnityEngine;

public class EndSceenManager : MonoBehaviour
{
    manager manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameObject.FindAnyObjectByType<manager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
