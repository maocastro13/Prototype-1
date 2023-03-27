using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; // el objetivo a seguir (el vehículo)
    public float smoothSpeed = 0.125f; // la velocidad de seguimiento
    public Vector3 offset; // el desplazamiento de la cámara con respecto al objetivo

    private float turnSpeed = 10f; // la velocidad de giro de la cámara

    void LateUpdate()
    {
        // Calcula la posición deseada de la cámara
        Vector3 desiredPosition = target.TransformPoint(offset); // convierte la posición local de offset en una posición global
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // interpola suavemente la posición actual de la cámara hacia la posición deseada
        transform.position = smoothedPosition; // actualiza la posición de la cámara

        // Calcula la rotación deseada de la cámara
        Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
        Quaternion smoothedRotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * turnSpeed);

        transform.rotation = smoothedRotation; // actualiza la rotación de la cámara
    }
}
