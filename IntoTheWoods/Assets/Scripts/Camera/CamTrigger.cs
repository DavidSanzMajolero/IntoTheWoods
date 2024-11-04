using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    public CameraController cameraController;
    public float cameraMoveDistance = 18.17f;

    // Variable para rastrear si el jugador ya pasó por el trigger
    private bool cameraMovedForward = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Si la cámara no se ha movido aún, muévela hacia adelante
            if (!cameraMovedForward)
            {
                cameraController.MoveCamera(cameraMoveDistance); // Mueve hacia adelante
                cameraMovedForward = true; // Marca que la cámara ya se ha movido hacia adelante
            }
            else
            {
                cameraController.MoveCamera(-cameraMoveDistance); // Mueve hacia atrás
                cameraMovedForward = false; // Marca que la cámara ha vuelto a la posición original
            }
        }
    }
}
