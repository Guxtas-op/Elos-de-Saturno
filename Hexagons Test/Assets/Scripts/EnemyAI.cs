using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Player player;
    public GameObject bulletPrefab;

    public float timer;
    private bool guns = true;

    public float power;

    public Transform leftGunPos;
    public Transform rightGunPos;

    void Update()
    {
        if (guns == true)
        {
            LeftAttackPlayer();
            RightAttackPlayer();
        }
    }

     void LeftAttackPlayer()
    {
        guns = false;
        GameObject bulletFire = Instantiate (bulletPrefab, leftGunPos.position, Quaternion.identity);
        Vector3 direction = (player.transform.position - leftGunPos.position).normalized * power;
        bulletFire.GetComponent<Rigidbody>().velocity = direction;
        Invoke(nameof(ResetEnemyFire), timer);
    }

    void RightAttackPlayer()
    {
        guns = false;
        GameObject bulletFire = Instantiate (bulletPrefab, rightGunPos.position, Quaternion.identity);
        Vector3 dir = (player.transform.position - rightGunPos.position).normalized * power;
        bulletFire.GetComponent<Rigidbody>().velocity = dir;
        Invoke(nameof(ResetEnemyFire),timer);
    }
    
    void ResetEnemyFire()
    {
        guns = true;
    }
}
