using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBasicAttack : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Despawn(15.5f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {   
            StartCoroutine(BasicDamageBoss(other.gameObject));
        }
    }

    IEnumerator BasicDamageBoss(GameObject player)
    {
        player.GetComponent<PlayerLife>().Damage(0.4f);
        gameObject.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds (0.5f); 
        Destroy(this.gameObject);
        
    }


    IEnumerator Despawn(float timerRighLeft)
    {
        yield return new WaitForSeconds(timerRighLeft);
        Destroy(this.gameObject);
    }
}

