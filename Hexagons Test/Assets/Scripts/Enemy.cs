using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyMaxHealth = 5;
    public float enemyDamage = 1f;
    float enemyCurrentHealth;

    public float speed;
    Rigidbody rb;

    public static bool isDead = false;
    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(-(transform.forward) * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerLife>().Damage(enemyDamage);
            Destroy(gameObject);
        }
    }

    // public void Damage (int enemyDamage) //Classe para o dano
    // {
    //     if(!isDead)
    //     { 
    //         enemyCurrentHealth -= enemyDamage; //Damage
    //         //Instantiate(damageParticle,transform.position,transform.rotation); //intacia a particula (Future add) 
    //         //anim.SetTrigger("isHit");//Animaçao de dano ( Future Add)
    //         //PlaySong(danoSong);//Audio dano (Future Add)
    //     }
    //     if (enemyCurrentHealth <= 0) 
    //     {
    //         isDead = true;
    //         //anim.SetTrigger("isDeath"); //Animaçao de morte (Future Add)
    //         EnemyDead();
    //     }
    // }
    
    void EnemyDead () 
    { 
        //PlaySong(morteSong);//Audio de morte (Future Add)
        StartCoroutine (EnemyDeath());
    }
    IEnumerator EnemyDeath()
    {
        yield return new WaitForSeconds (2);
        Destroy (gameObject);
        //SceneManager.LoadScene (Death); (Future Add)
    }
}
