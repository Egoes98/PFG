using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    
    [Header("Move Parameters")]
    [Range(0f,10f)]
    public float speed;
    public float gravity = -9.81f;
    [Range(0f,10f)]
    public float jumpHeight = 3;

    [Header("Ground Checking Parameters")]
    public Transform groundCheck;
    [Range(0f,1f)]
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        GameObject gM = GameObject.FindGameObjectWithTag("GameManager");
        transform.position = gM.GetComponent<GameManager>().getPos();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Capturar Input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //calcular el vector de movimiento
        Vector3 move = transform.right * x + transform.forward * z;

        //Enviar movimiento al controler para que lo procese
        controller.Move(move * speed * Time.deltaTime);

        //Detectar tecla de salto y si el jugador esta bien posicionado
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        //Enviar parametros para realizar el salto
        controller.Move(velocity * Time.deltaTime);
    }
}
