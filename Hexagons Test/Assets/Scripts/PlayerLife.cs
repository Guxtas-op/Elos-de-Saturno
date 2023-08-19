//using UnityEngine.SceneManagement; (Future add)
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public Image lifebar;
    public Image redBar;

    public int maxHealth = 5;
    public int currentHealth;
    public int damageCount = 1;
     
    public bool isDead = false; //Morte
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void SetHealth()
    {
        Vector3 lifebarScale = lifebar.rectTransform.localScale;
        lifebarScale.x = (float) currentHealth / maxHealth;
        lifebar.rectTransform.localScale = lifebarScale;
        StartCoroutine(DecreasingRedBar(lifebarScale));
    }

    IEnumerator DecreasingRedBar(Vector3 newScale)
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 redBarScale = redBar.transform.localScale;

        while (redBar.transform.localScale.x > newScale.x)
        {
            redBarScale.x -= Time.deltaTime * 0.25f;
            redBar.transform.localScale = redBarScale;

            yield return null;
        }
        redBar.transform.localScale = newScale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Meteoro")
        {
            Destroy(collision.gameObject,1.5f);
            Damage();
        }
    }
    
    public void Damage() //Classe para o dano
    {
        if(!isDead)
        { 
            currentHealth -= damageCount;
            SetHealth(); // Damage
            //Instantiate(damageParticle,transform.position,transform.rotation); //intacia a particula (Future add) 
            //anim.SetTrigger("isHit");//Animaçao de dano ( Future Add)
            //PlaySong(danoSong);//Audio dano (Future Add)
        }

        if (currentHealth <= 0) 
        {
            isDead = true;
            //anim.SetTrigger("isDeath"); //Animaçao de morte (Future Add)
            Dead();
        }
    }
    void Dead () 
    { 
        //PlaySong(morteSong);//Audio de morte (Future Add)
        StartCoroutine (Death());
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds (2);
        Destroy (gameObject);
        //SceneManager.LoadScene (Death); (Future Add)
    }
}