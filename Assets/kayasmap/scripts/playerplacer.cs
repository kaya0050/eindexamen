using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class playerplacer : MonoBehaviour
{
    public List<GameObject> players = new List<GameObject>();
    public List<GameObject> places = new List<GameObject>();

    public bool blockmoving = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        players = GameObject.FindGameObjectsWithTag("Player").ToList<GameObject>();
        players = players.OrderByDescending(p => p.GetComponent<playermanager>().points).ToList();
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
            if (blockmoving)
            {
                players[i].GetComponent<PlayerMovement>().enabled = false;
            }
            else
            {
                players[i].GetComponent<PlayerMovement>().enabled = true;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
