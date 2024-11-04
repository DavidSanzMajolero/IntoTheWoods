using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    public CameraController cameraController;
    public float cameraMoveDistance = 18.17f;

    // Variable para rastrear si el jugador ya pas� por el trigger
    private bool cameraMovedForward = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Si la c�mara no se ha movido a�n, mu�vela hacia adelante
            if (!cameraMovedForward)
            {
                cameraController.MoveCamera(cameraMoveDistance); // Mueve hacia adelante
                cameraMovedForward = true; // Marca que la c�mara ya se ha movido hacia adelante
            }
            else
            {
                cameraController.MoveCamera(-cameraMoveDistance); // Mueve hacia atr�s
                cameraMovedForward = false; // Marca que la c�mara ha vuelto a la posici�n original
            }
        }
    }
}
