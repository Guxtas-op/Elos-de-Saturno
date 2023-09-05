using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public Player player;
    public GameObject frozenBallPrefab;
    public float cooldown;
    private bool fire = true;
    public float strength;
    public float life;

    public Transform armaPos;

    void Update()
    {
        if(fire == true)
        {
            AttackPlayer();
        }
    }

    void AttackPlayer()
    {
        fire = false;
        GameObject frozenBall = Instantiate (frozenBallPrefab, armaPos.position, Quaternion.identity);
        Vector3 impulse = (player.transform.position - armaPos.position).normalized * strength;
        frozenBall.GetComponent<Rigidbody>().velocity = impulse;
        Invoke(nameof(ResetFrozenFire), cooldown);
    }

    void ResetFrozenFire()
    {
        fire = true;
    }
}
