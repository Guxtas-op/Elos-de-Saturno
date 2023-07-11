using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyMaxHealth = 5;
    private int enemyDamage;
    int enemyCurrentHealth;

    public static bool isDead = false;
    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Damage(enemyDamage);
        }
    }

    public void Damage (int enemyDamage) //Classe para o dano
    {
        if(!isDead)
        { 
            enemyCurrentHealth -= enemyDamage; //Damage
            //Instantiate(damageParticle,transform.position,transform.rotation); //intacia a particula (Future add) 
            //anim.SetTrigger("isHit");//Animaçao de dano ( Future Add)
            //PlaySong(danoSong);//Audio dano (Future Add)
        }
        if (enemyCurrentHealth <= 0) 
        {
            isDead = true;
            //anim.SetTrigger("isDeath"); //Animaçao de morte (Future Add)
            EnemyDead();
        }
    }
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
