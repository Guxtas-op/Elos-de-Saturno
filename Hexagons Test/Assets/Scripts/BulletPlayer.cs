using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    public bool bulletCount = true; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Meteoro")
        {  
            if(bulletCount == true)
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                bulletCount = false;
                StartCoroutine(Reactive());
            }
        }

        if (other.gameObject.CompareTag("Boss"))
        {  
            if(bulletCount == true)
            {
               StartCoroutine(EnemyDamage(other.gameObject));
               
            }
        }
    }


    IEnumerator EnemyDamage(GameObject boss)
    {
        boss.GetComponent<BossLife>().canTakeDamage = true;
        boss.GetComponent<BossLife>().EnemyDamage(1.5f); 
        yield return new WaitForSeconds (0.1f); 
        Destroy(this.gameObject);
        bulletCount = false;
    }

    IEnumerator Reactive()
    {
        bulletCount = true;
        yield return null;
    }
    
}

