using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] itemsToRandomize;
    public BoxCollider bounds;
    
    public GameObject enemyPrefab;

    public float timer;

    void Start()
    {
        StartCoroutine(nameof(SpawnEnemy));
    }

    IEnumerator SpawnNaveInimiga()
    {
        Vector3 randomPos = RandomPointInBounds(bounds.bounds);
        GameObject enemy = Instantiate(enemyPrefab, randomPos, transform.rotation * Quaternion.Euler(-90f,0f,0f));
        yield return new WaitForSeconds(timer);
        StartCoroutine(nameof(SpawnEnemy));
    }

    Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }
}
