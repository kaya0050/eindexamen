using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class playerplacer : MonoBehaviour
{
    public List<GameObject> players = new List<GameObject>();
    public List<GameObject> places = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        players = GameObject.FindGameObjectsWithTag("Player").ToList<GameObject>();
        for (int i = 0; i < players.Count; i++)
        {
            CharacterController cc = players[i].GetComponent<CharacterController>();
            // om velocity van de character contoller op 0 te zetten tijdelijk anders kan hij niet goed teleporteren
            if (cc != null)
            {
                cc.enabled = false;
            }

            if (i < places.Count)
            {
                players[i].transform.position = places[i].transform.position;
            }
            else
            {
                players[i].transform.position = transform.position;
            }

            if (cc != null)
            {
                cc.enabled = true;
            }

            Debug.Log(players[i].transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
