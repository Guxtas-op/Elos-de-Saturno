using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] public string nomeDolevelDeJogo;
    [SerializeField] public GameObject painelMenuInicial;
    [SerializeField] public GameObject painelOpcoes;
    [SerializeField] public GameObject painelcredits;
    [SerializeField] public GameObject painelFases;

   public void Jogar()
   {
        SceneManager.LoadScene(nomeDolevelDeJogo);
   }

   public void AbrirOpcoes()
   {
     painelMenuInicial.SetActive(false);
     painelOpcoes.SetActive(true);
   }

   public void FecharOpcoes()
   {
     painelOpcoes.SetActive(false);
     painelMenuInicial.SetActive(true);
   }

   public void SairJogo()
   {
     Debug.Log("sair do jogo");
     Application.Quit();
   }

   public void Credits()
   {
     painelMenuInicial.SetActive(false);
     painelcredits.SetActive(true);
   }

    public void FecharCredits()
   {
     painelcredits.SetActive(false);
     painelMenuInicial.SetActive(true);
   }

   public void AbrirFases()
   {
     painelMenuInicial.SetActive(false);
     painelFases.SetActive(true);
   }

   
}
