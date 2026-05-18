using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class FireBallSpawner : MonoBehaviour
{
    public GameObject fireBall;
    public Transform[] fireBallSpawnPoint;

    private float fireCooldown = 2f;
    public bool gameStarted = false;

    void Update()
    {
        if (gameStarted)
        {
            fireCooldown -= Time.deltaTime;
        }

        if (fireCooldown <= 0)
        {
            fireCooldown = 2f;
            int amountToSpawn = Random.Range(2,4);

            List<int> usedSpawnPoints = new List<int>();

            for (int i = 0; i < amountToSpawn; i++)
            {
                int RandomSpawnPoint;

                do
                {
                    RandomSpawnPoint = Random.Range(0, fireBallSpawnPoint.Length);
                }
                while (usedSpawnPoints.Contains(RandomSpawnPoint));

                usedSpawnPoints.Add(RandomSpawnPoint);

                Transform spawnPoint = fireBallSpawnPoint[RandomSpawnPoint];

                Instantiate(fireBall, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}
