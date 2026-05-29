using UnityEngine;

public class PlayerModelSelector : MonoBehaviour
{
    public GameObject model1;
    public GameObject model2;
    public GameObject model3;
    public GameObject model4;

    public Manager manager;
    public Canvas canvas;

    // selecteerd een model en geeft hem aan de speler
    void Select(GameObject model)
    {
        Instantiate(model,manager.currentPlayer.transform);
        canvas.enabled = false;
    }
    //funtie verwijzingen alleen voor buttons
    public void SelModel1() => Select(model1);
    public void SelModel2() => Select(model2);
    public void SelModel3() => Select(model3);
    public void SelModel4() => Select(model4);

}