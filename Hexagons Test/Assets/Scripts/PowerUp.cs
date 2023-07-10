using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int oxigen;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Oxigen"))
        {
            Destroy(collision.gameObject);
            oxigen++;
        }
    }
}
