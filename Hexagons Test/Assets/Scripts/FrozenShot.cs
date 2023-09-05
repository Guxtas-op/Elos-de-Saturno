using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenShot : MonoBehaviour
{
    public float damagePlayer = 1;

    private void Start()
    {
        StartCoroutine(Despawn(20f));
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bunda");
        if (other.gameObject.CompareTag("Player"))
        {  
            if(other.gameObject.GetComponent<Player>().isFrozen)
                return;
            StartCoroutine(Froze(other.gameObject));    
        }
    }

    IEnumerator Froze(GameObject plr)
    {
        plr.GetComponent<Player>().isFrozen = true;
        plr.GetComponent<PlayerLife>().Damage(0.5f);
        yield return new WaitForSeconds (2.5f);
        plr.GetComponent<Player>().isFrozen = false;
        Destroy(this.gameObject);
    }

    IEnumerator Despawn(float timer)
    {
        yield return new WaitForSeconds(timer);
        Destroy(this.gameObject);
    }
}
