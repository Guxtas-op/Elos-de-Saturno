using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenShot : MonoBehaviour
{
    public float damagePlayer;

    void Update()
    {
        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if(other.gameObject.GetComponent<Player>().isFrozen)
                    return;
                StartCoroutine(Froze(other.gameObject));

                if(other.gameObject.CompareTag("Player"))
                {
                    Destroy(other.gameObject,0.3f);
                }
            }
        }

        IEnumerator Froze(GameObject plr)
        {
            plr.GetComponent<Player>().isFrozen = true;
            plr.GetComponent<PlayerLife>().Damage(2f);
            yield return new WaitForSeconds (2.5f);
            plr.GetComponent<Player>().isFrozen = false;
        }
    }
}
