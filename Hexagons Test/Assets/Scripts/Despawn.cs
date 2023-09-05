using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    void Start()
    {
        StartCoroutine((DespawnItens(5.5f)));
    }

    IEnumerator DespawnItens(float timer)
    {
        Debug.Log("despawn");
        yield return new WaitForSeconds(timer);
        Destroy(this.gameObject);
    }

}
