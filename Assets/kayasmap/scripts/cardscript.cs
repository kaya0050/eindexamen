using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cardscript : MonoBehaviour
{
    public carddeckscript carddeckscript;
    public bool isPulled = false;
    public string minigameescene;
    public Vector3 startPos;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseCard()
    {
        carddeckscript.manager.cards.Remove(gameObject);
        Destroy(gameObject);
        SceneManager.LoadScene(minigameescene);
    }
    public void HighlightCard()
    {
        transform.position = startPos + new Vector3(0, math.sin(Time.time * 5) * 0.02f, 0);
    }
}
