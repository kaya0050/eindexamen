using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardScript : MonoBehaviour
{
    public CardDeckScript cardDeckScript;
    public bool isPulled = false;
    public string minigameScene;
    public Vector3 startPos;

    public void UseCard()
    {
        cardDeckScript.manager.cards.Remove(gameObject);
        Destroy(gameObject);
        cardDeckScript.manager.inMinigame = true;
        SceneManager.LoadScene(minigameScene);
    }
    public void HighLightCard()
    {
        transform.position = startPos + new Vector3(0, math.sin(Time.time * 5) * 0.02f, 0);
    }
}
