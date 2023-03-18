using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnTimer;

    private void OnEnable()
    {
        EventManager.onStartGame += StartSpawning;
        EventManager.onPlayerDead += StopSpawning;
    }

    private void OnDisable()
    {
        EventManager.onStartGame -= StopSpawning;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

    void StartSpawning()
    {
        InvokeRepeating("SpawnEnemy", spawnTimer, spawnTimer);
    }

    void StopSpawning()
    {
        CancelInvoke();
    }
}
