using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [Range(0f,1000f)]
    public float mouseSensitivity = 1000f;
    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        //Par que el cusros se mantenga dentro de los limites de la pantalla.
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Recogemos el input del movimiento del raton
        float mouseX = Input.GetAxis("Mouse X") *  mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Se aplica la ritacion al cuerpo del jugador
        playerBody.Rotate(Vector3.up * mouseX);

        //Se calcula la rotacion y se aplica a la rotacion de la camara
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
