using UnityEngine;

public class playermodelselector : MonoBehaviour
{
    public GameObject model1;
    public GameObject model2;
    public GameObject model3;
    public GameObject model4;

    public PlayerMovement playerMovement;
    public playermanager playermanager;

    bool hasSelectedModel = false;

    void Start()
    {
        playerMovement.enabled = false;
    }

    void Update()
    {
        if (!hasSelectedModel)
        {

        }
    }

    void Select(GameObject model)
    {
        Instantiate(model, playermanager.gameObject.transform);

        hasSelectedModel = true;
        playerMovement.enabled = true;
        for (int i = 0; i < playermanager.buttonsInCanvas.Count; i++)
        {
            playermanager.buttonsInCanvas[i].active = false;
        }
        
    }

    public void selmodel1()
    {
        Select(model1);
    }

    public void selmodel2()
    {
        Select(model2);
    }

    public void selmodel3()
    {
        Select(model3);
    }

    public void selmodel4()
    {
        Select(model4);
    }
}