using System.Collections.Generic;
using UnityEngine;

public class carddeckscript : MonoBehaviour
{
    public manager manager;
    public List<Transform> cardspositions = new List<Transform>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameObject.Find("manager").GetComponent<manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            DealCards();
        }
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

        for (int i = 0; i < manager.cards.Count; i++)
        {
            manager.cards[i].transform.position = cardspositions[i].position;
            cardscript cardscript = manager.cards[i].GetComponent<cardscript>();
            cardscript.startPos = cardspositions[i].position;
        }
    }
}
