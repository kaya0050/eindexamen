using System.Collections.Generic;
using UnityEngine;

public class carddeckscript : MonoBehaviour
{
    public List<GameObject> cards = new List<GameObject>();
    public List<Transform> cardspositions = new List<Transform>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DealCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DealCards()
    {
        //shufflecards
        for (int i = 0; i < cardspositions.Count; i++)
        {
            int randomIndex = Random.Range(i, cardspositions.Count);

            Transform temp = cardspositions[i];
            cardspositions[i] = cardspositions[randomIndex];
            cardspositions[randomIndex] = temp;
        }

        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].transform.position = cardspositions[i].position;
            cardscript cardscript = cards[i].GetComponent<cardscript>();
            cardscript.startPos = cardspositions[i].position;
        }
    }
}
