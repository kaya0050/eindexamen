using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cardscript : MonoBehaviour
{
    public carddeckscript carddeckscript;
    public bool isPulled = false;
    public string minigameescene;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseCard()
    {
        carddeckscript.cards.Remove(gameObject);
        SceneManager.LoadScene(minigameescene);
        
       
       
    }
}
