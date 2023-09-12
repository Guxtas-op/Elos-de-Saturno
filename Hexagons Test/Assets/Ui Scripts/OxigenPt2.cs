using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class OxigenPt2 : MonoBehaviour
{
    private CharacterController controller;
    private GameObject Player;

    public Image OxigenBar;

    [Range(20, 500)]
    public float maxOxigen = 100;

    [HideInInspector]
    public float currentOxigen;
    private float oxigenTimer;

    //chamar componentes

    void Start()
    {
        //Componentes KKKKKK
        controller = GetComponent<CharacterController>();
        currentOxigen = maxOxigen;
        Player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        OxigenSistem(); //chamar um método
    }

    void AplicarBarras()
    {
        OxigenBar.fillAmount = ((1 / maxOxigen) * currentOxigen);
    }

    void OxigenSistem() //método  KKKKKKK

    {
        currentOxigen -= Time.deltaTime;

        if (currentOxigen >= maxOxigen)
        {
            currentOxigen = maxOxigen; //setando o oxigenio igual ao valor max que vc colocou pra n dar bugs.
        }

        if (currentOxigen <= 0)
        {
            currentOxigen = 0;
            oxigenTimer += Time.deltaTime;  //se for 0, adicionar um timer.

            if (oxigenTimer >= 3)
            {
                oxigenTimer = 0;    //se o timer > 3 mudar o timer para 0, ativando a função anterior.
            }
        }
        else
        {
            oxigenTimer = 0;   //se não será 0 da mesma forma.
        }
    }

}



