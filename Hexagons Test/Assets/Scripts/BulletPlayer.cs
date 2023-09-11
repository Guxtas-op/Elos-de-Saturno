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
/*
        if (collision.gameObject.CompareTag("Boss"))
        {  
            if(bulletCount == true)
            {
               StartCoroutine(Damage(other.gameObject));
               
            }
        }
    }


    IEnumerator Damage(GameObject boss)
    {
        boss.GetComponent<Boss>().canTakeDamage = true;
        boss.GetComponent<BossLife>().Damage(2.5f); 
        yield return new WaitForSeconds (0.1f); 
        Destroy(this.gameObject);
        bulletCount = false;
    }
*/
    IEnumerator Reactive()
    {
        yield return new WaitForSeconds (0.1f); 
        bulletCount = true;
    }

    }
}
