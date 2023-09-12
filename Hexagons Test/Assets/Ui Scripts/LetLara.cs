using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetLara : MonoBehaviour
{

    //[Explicação]
    // vou ter que nerdolar, me desculpe já.
    // seguinte, esse script tem a função de procurar o player
    // Detectar uma colisão
    // se o objeto colidido for o Player, adicione certa quantidade (valor) ao currentOxigen (oxigenioAtual)
    //Destrua o oxigenio

    [Range(1, 500)]
    public float Quantity = 50;
    private GameObject Player;

    void Start()
    {
        Player = GameObject.FindWithTag("Player"); //find with tag player (Procurar por tag)
    }
    void OnTriggerEnter(Collider other) //colisão por trigger
    {
        if (other.gameObject == Player.gameObject)
        {
            Player.GetComponent<OxigenPt2>().currentOxigen += Quantity;
            Destroy(gameObject);
        }
    }
}


