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
        //Alleen spawnen als de game gestart is.
        if (gameStarted)
        {
            fireCooldown -= Time.deltaTime;
        }

        //Zodra cooldown voorbij is spawnen er nieuwe fireballs.
        if (fireCooldown <= 0)
        {
            //Reset cooldown.
            fireCooldown = 2f;

            //Kies willekeurig aantal fireballs om te spawnen.
            int amountToSpawn = Random.Range(2, 4);

            //Houd bij welke spawnpoints al gebruikt zijn.
            List<int> usedSpawnPoints = new List<int>();

            for (int i = 0; i < amountToSpawn; i++)
            {
                int RandomSpawnPoint;

                //Blijf zoeken tot je een ongebruikt spawnpoint hebt.
                do
                {
                    RandomSpawnPoint = Random.Range(0, fireBallSpawnPoint.Length);
                }
                while (usedSpawnPoints.Contains(RandomSpawnPoint));

                usedSpawnPoints.Add(RandomSpawnPoint);

                //Spawn fireball op gekozen locatie.
                Transform spawnPoint = fireBallSpawnPoint[RandomSpawnPoint];

                Instantiate(fireBall, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}