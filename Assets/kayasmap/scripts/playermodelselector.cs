using UnityEngine;

public class playermodelselector : MonoBehaviour
{
    public GameObject model1;
    public GameObject model2;
    public GameObject model3;
    public GameObject model4;

    public PlayerMovement playerMovement;
    public playermanager playerManager;

    public manager manager;
    public Canvas canvas;

    void Start()
    {

    }

    void Update()
    {
        if (manager && manager.currentPlayer)
        {
            playerMovement = manager.currentPlayer.GetComponent<PlayerMovement>();
            playerManager = manager.currentPlayer.GetComponent<playermanager>();
        }
    }
    // selecteerd een model en geeft hem aan de speler
    void Select(GameObject model)
    {
        Instantiate(model,manager.currentPlayer.transform);
        canvas.enabled = false;
    }
    //funtie verwijzingen alleen voor buttons
    public void selmodel1() => Select(model1);
    public void selmodel2() => Select(model2);
    public void selmodel3() => Select(model3);
    public void selmodel4() => Select(model4);

}