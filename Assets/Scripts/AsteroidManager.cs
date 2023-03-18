using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] Asteroid asteroidPrefab;
    [SerializeField] float asteroidSpacing = 10f;
    [SerializeField] int numberOfAsteroids = 100;
    [SerializeField] Vector3 minPosition;
    [SerializeField] Vector3 maxPosition;

    [SerializeField] GameObject pickupPrefabs;

    public List<Asteroid> asteroids = new List<Asteroid>();

    private void OnEnable()
    {
        EventManager.onStartGame += PlaceAsteroids;
        EventManager.onPlayerDead += DestroyAsteroids;
        EventManager.onReSpawnPickup += PlacePickup;
    }

    private void OnDisable()
    {
        EventManager.onStartGame -= PlaceAsteroids;
        EventManager.onPlayerDead -= DestroyAsteroids;
        EventManager.onReSpawnPickup -= PlacePickup;
    }

    void DestroyAsteroids()
    {
        foreach (Asteroid ast in asteroids)
        {
            ast.SelfDestruct();
        }
        asteroids.Clear();
    }

    void PlaceAsteroids()
    {
        for (int i = 0; i < numberOfAsteroids; i++)
        {
            Vector3 asteroidPos = Random.insideUnitSphere * asteroidSpacing + transform.position;
            InstantiateAsteroid(asteroidPos);
        }
        PlacePickup();
    }

    void InstantiateAsteroid(Vector3 position)
    {
        Vector3 randomPosition = new Vector3(
        Random.Range(minPosition.x, maxPosition.x),
        Random.Range(minPosition.y, maxPosition.y),
        Random.Range(minPosition.z, maxPosition.z));

        Asteroid temp = Instantiate(asteroidPrefab, randomPosition, Quaternion.identity, transform) as Asteroid;
        asteroids.Add(temp);
    }

    void PlacePickup()
    {
        int rnd = Random.Range(0, asteroids.Count);

        Instantiate(pickupPrefabs, asteroids[rnd].transform.position, Quaternion.identity);
        Destroy(asteroids[rnd].gameObject);
        asteroids.RemoveAt(rnd);
    }
}
