using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
   public GameObject[] itemsToRandomize;
   public BoxCollider bounds;

   public GameObject meteorPrefab;
   public GameObject oxigenPrefab;
   public float coolDown;

    void Start()
    {
        StartCoroutine(nameof(SpawnMeteor));
        StartCoroutine(nameof(SpawnOxigen));
    }

    IEnumerator SpawnMeteor()
    {
        Vector3 randomPos = RandomPointInBounds(bounds.bounds);
        GameObject meteorObj = Instantiate(meteorPrefab, randomPos, Quaternion.identity);
        yield return new WaitForSeconds(coolDown);
        StartCoroutine(nameof(SpawnMeteor));
    }

    IEnumerator SpawnOxigen()
    {
        Vector3 randomPos = RandomPointInBounds(bounds.bounds);
        GameObject meteorObj = Instantiate(oxigenPrefab, randomPos, transform.rotation * Quaternion.Euler(-90f,0f,0f));
        yield return new WaitForSeconds(coolDown*2);
        StartCoroutine(nameof(SpawnOxigen));
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
