using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool CanSpawn;
    public float TimeSpawn;
    private bool Spawning;
    public GameObject[] EnemyPrefabs;
    public Transform[] SpawnPoints;

    void Start()
    {
        if (CanSpawn)
        {
            CanSpawn = true;
            StartCoroutine(SpawnEnemy());
        }
    }

    void Update()
    {
        if (CanSpawn && !Spawning)
        {
            foreach (Transform spawnPoint in SpawnPoints)
            {
                int randomIndex = Random.Range(0, EnemyPrefabs.Length);
                GameObject prefabEnemigo = EnemyPrefabs[randomIndex];

                Instantiate(prefabEnemigo, spawnPoint.position, spawnPoint.rotation);
            }
            Spawning = true;
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeSpawn);
            if (CanSpawn)
            {
                foreach (Transform spawnPoint in SpawnPoints)
                {
                    int randomIndex = Random.Range(0, EnemyPrefabs.Length);
                    GameObject prefabEnemigo = EnemyPrefabs[randomIndex];

                    Instantiate(prefabEnemigo, spawnPoint.position, spawnPoint.rotation);
                }
                Spawning = false;
            }
        }
    }
}
