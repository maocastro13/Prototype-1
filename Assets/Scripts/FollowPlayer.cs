using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; // el objetivo a seguir (el vehículo)
    public float smoothSpeed = 0.125f; // la velocidad de seguimiento
    public Vector3 offset; // el desplazamiento de la cámara con respecto al objetivo

    private float turnSpeed = 10f; // la velocidad de giro de la cámara
    private bool isDriverView = false; // indica si la cámara está en la vista del conductor o en la vista posterior
    private Vector3 driverOffset = new Vector3(0f, 2f, 0.5f); // el desplazamiento de la cámara desde la vista del conductor
    private Vector3 rearOffset = new Vector3(0f, 3f, -7f); // el desplazamiento de la cámara desde la vista posterior
    private float driverForwardOffset = 2f; // la cantidad de desplazamiento hacia adelante de la cámara en la vista del conductor

    
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isDriverView = !isDriverView; // cambiar entre vistas de cámara
        }

        // calcula la posición deseada de la cámara en función de la vista de la cámara seleccionada
        Vector3 desiredPosition;
        if (isDriverView)
        {
            // mueve la posición de la cámara hacia adelante en la dirección del movimiento del vehículo
            Vector3 driverForwardPosition = target.position + target.forward * driverForwardOffset;
            desiredPosition = driverForwardPosition + target.up * driverOffset.y + target.right * driverOffset.x + target.forward * driverOffset.z;
        }
        else
        {
            desiredPosition = target.TransformPoint(rearOffset);
        }


        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // interpola suavemente la posición actual de la cámara hacia la posición deseada
        transform.position = smoothedPosition; // actualiza la posición de la cámara

        // calcula la rotación deseada de la cámara en función de la vista de la cámara seleccionada
        Quaternion desiredRotation;
        if (isDriverView)
        {
            desiredRotation = target.rotation; // rotación deseada de la vista del conductor
        }
        else
        {
            desiredRotation = Quaternion.LookRotation(target.position - transform.position, target.up); // rotación deseada de la vista posterior
        }

        Quaternion smoothedRotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * turnSpeed);
        transform.rotation = smoothedRotation; // actualiza la rotación de la cámara
    }
}

