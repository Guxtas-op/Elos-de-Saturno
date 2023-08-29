using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeOxigenio : MonoBehaviour
{
    public float BarraDeVida;
    public float BarraDeFome;
 
    public Slider BarraDeFomeSlider;
    public Slider BarraDeVidaSlider;
 
    public GameObject DIEMenu;

    // Start is called before the first frame update
    void Start()
    {
       BarraDeVida = PlayerPrefs.GetFloat("Barradevidasalva", 100);
       BarraDeFome = PlayerPrefs.GetFloat("Barradefomesalva", 100);
    }

    // Update is called once per frame
    void Update()
    {
       PlayerPrefs.SetFloat("Barradevidasalva", BarraDeVida);
        PlayerPrefs.SetFloat("Barradefomesalva", BarraDeFome);
 
        BarraDeFome -= 0.015f;
        BarraDeVida += 0.03f;
 
        BarraDeFomeSlider.value = BarraDeFome;
        BarraDeVidaSlider.value = BarraDeVida;
 
        if(BarraDeFome > 100)
        {
            BarraDeFome = 100;
        }
 
        if(BarraDeVida <= 0)
        {
            BarraDeVida = 0f;
 
            //Voce colocar o que quiser
            DIEMenu.active = true;
        }
 
        if (BarraDeVida > 100)
        {
            BarraDeVida = 100;
        }
 
        if (BarraDeFome <= 0)
        {
            BarraDeVida -= 0.15f;
            BarraDeFome = 0f;
        }

    }

     public void botao1()
    {
        PlayerPrefs.DeleteKey("Barradevidasalva");
        PlayerPrefs.DeleteKey("Barradefomesalva");
        Application.LoadLevel(0);
    }
 
    public void botao2()
    {
        BarraDeFome += 20f;
    }
}
