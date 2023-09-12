using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public Player player;

    public GameObject frozenBallPrefab;
    public GameObject basicBallPrefab;

    public float cooldown;
    public float cdr;

    private bool fire = true;
    private bool attack = true;

    public float strength;
    public float power;

    public Transform armaPos;
    public Transform lArmaPos;
    public Transform rArmaPos;

    void Update()
    {
        if(fire == true)
        {
            AttackPlayer();
        }

        if(attack == true)
        {
            LeftAttackPlayer();
            RightAttackPlayer();
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

     void LeftAttackPlayer()
    {
        attack = false;
        GameObject basicBall = Instantiate (basicBallPrefab, lArmaPos.position, Quaternion.identity);
        Vector3 direction = (player.transform.position - lArmaPos.position).normalized * power * 2;
        basicBall.GetComponent<Rigidbody>().velocity = direction;
        Invoke(nameof(ResetFire), cooldown);
    }

    void RightAttackPlayer()
    {
        attack = false;
        GameObject basicBall = Instantiate (basicBallPrefab, rArmaPos.position, Quaternion.identity);
        Vector3 dir = (player.transform.position - rArmaPos.position).normalized * power * 2;
        basicBall.GetComponent<Rigidbody>().velocity = dir;
        Invoke(nameof(ResetFire), cdr);
    }
    
    void ResetFrozenFire()
    {
        fire = true;
    }

    void ResetFire()
    {
        attack = true;
    }
}
