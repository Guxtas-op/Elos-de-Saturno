using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxigen : MonoBehaviour
{
    public GameObject oxigen;
    public int oxigenCount;
    public float speed;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce((transform.up) * speed);
    }

    void Update()
    {
        //transform.Rotate(new Vector3 (0,0,100) * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
         if(collision.gameObject.tag == "Player")
        {
            Destroy(oxigen);
            Debug.Log("Oxigenio Coletado");
            oxigenCount ++; 
        }
    }
}
