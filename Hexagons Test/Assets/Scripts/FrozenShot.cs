using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenShot : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Despawn(15.5f));
    }

    private void OnTriggerEnter(Collider other)
    {
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
        gameObject.GetComponent<Renderer>().enabled = false;
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
