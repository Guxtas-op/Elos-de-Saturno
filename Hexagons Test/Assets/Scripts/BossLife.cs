using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BossLife : MonoBehaviour
{
    public Image lifebar;
    public Image redBar;

    public float enemyMaxHealth = 5;
    public float enemyCurrentHealth;

    public bool enemyIsDead = false;
    public bool canTakeDamage = true;

    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }

    public void EnemySetHealth()
    {
        Vector3 lifebarScale = lifebar.rectTransform.localScale;
        lifebarScale.x = (float) enemyCurrentHealth / enemyMaxHealth;
        lifebar.rectTransform.localScale = lifebarScale;
        StartCoroutine(EnemyDecreasingRedBar(lifebarScale));
    }

    IEnumerator EnemyDecreasingRedBar(Vector3 newScale)
    {
        yield return new WaitForSeconds(0.3f);
        Vector3 redBarScale = redBar.transform.localScale;

        while (redBar.transform.localScale.x > newScale.x)
        {
            redBarScale.x -= Time.deltaTime * 0.25f;
            redBar.transform.localScale = redBarScale;

            yield return null;
        }
        redBar.transform.localScale = newScale;
    }
    

    public void EnemyDamage(float damage) //Classe para o dano
    {
        if(!enemyIsDead && canTakeDamage == true)
        { 
            enemyCurrentHealth -= damage;
            EnemySetHealth(); // Damage
            //Instantiate(damageParticle,transform.position,transform.rotation); //intacia a particula (Future add) 
            //anim.SetTrigger("isHit");//Animaçao de dano ( Future Add)
            //PlaySong(danoSong);//Audio dano (Future Add)
        }

        if (enemyCurrentHealth <= 0) 
        {
            enemyIsDead = true;
            //anim.SetTrigger("isDeath"); //Animaçao de morte (Future Add)
            Dead();
        }
    }
    void Dead () 
    { 
        //PlaySong(morteSong);//Audio de morte (Future Add)
        StartCoroutine (EnemyDeath());
    }
    IEnumerator EnemyDeath()
    {
        yield return new WaitForSeconds (2f);
        Destroy (gameObject);
    }

}
