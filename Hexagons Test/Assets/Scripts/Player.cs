using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializedField] private TransformReference globalPlayerPosition;

    private CharacterController controller;
    private Vector3 moveDirection;
    private Animator anim;

    public float speed;
    public bool isFrozen;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        Move();

        //globalPlayerPosition.value = transform.position;
    }

    void Move()
    {
        if (isFrozen)
            return;
            
        moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection = Vector3.left * speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveDirection = Vector3.right * speed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection = Vector3.up * speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveDirection = Vector3.down * speed;
        }
    
        controller.Move(moveDirection * Time.deltaTime);
    }
}
