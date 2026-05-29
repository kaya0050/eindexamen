using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public List<GameObject> pickupDrops;

    public int timer;
    public BoxCollider spawnArea;
    public int height = 5;
    public AudioSource audioSource;
    public AudioClip popSound;
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
        audioSource.PlayOneShot(popSound,1);
        Bounds bounds = spawnArea.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomZ = Random.Range(bounds.min.z, bounds.max.z);

        Vector3 randomPosition = new Vector3(randomX, height, randomZ);
        Instantiate(pickupDrops[Random.Range(0,pickupDrops.Count) ], randomPosition, Quaternion.identity);
    }
}

