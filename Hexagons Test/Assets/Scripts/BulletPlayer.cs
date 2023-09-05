using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    public float bulletCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Meteoro"))
        {  
            bulletCount ++ ;
            Debug.Log("certou");
            if(bulletCount >= 1)
            {
                Destroy(this.gameObject);

            }
        }
    }
}
