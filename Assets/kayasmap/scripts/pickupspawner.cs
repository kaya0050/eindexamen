using System.Collections.Generic;
using UnityEngine;

public class pickupspawner : MonoBehaviour
{
    public List<GameObject> pickup_drops;

    public int timer;
    public BoxCollider spawnArea;
    public int height = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    



    private void FixedUpdate()
    {
        timer--;

        if (timer < 0)
        {
            SpawnPickup();
            timer = 200;
        }
    }

    void SpawnPickup()
    {
        Bounds bounds = spawnArea.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomZ = Random.Range(bounds.min.z, bounds.max.z);

        Vector3 randomPosition = new Vector3(randomX, height, randomZ);
        Instantiate(pickup_drops[Random.Range(0,pickup_drops.Count) ], randomPosition, Quaternion.identity);
    }
}

