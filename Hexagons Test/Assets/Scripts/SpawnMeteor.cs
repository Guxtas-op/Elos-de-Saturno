using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteor : MonoBehaviour
{
   public GameObject meteor;
   public float coolDown;
    void Update()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(coolDown);
        Instantiate(meteor, transform.position, transform.rotation);
        yield return new WaitForSeconds(coolDown);

    }
}
