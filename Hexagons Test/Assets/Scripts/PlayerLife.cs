using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public Image lifebar;
    public Image redBar;

    public int maxHealth = 5;
    int currentHealth; //Atual

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void SetHealth(int amount)
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
    
}
