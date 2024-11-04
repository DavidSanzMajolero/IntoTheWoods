using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasLaberint : MonoBehaviour
{
    private GameObject Player;
    public Camera CurrentCamera;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");

        if (CurrentCamera == null)
        {
            CurrentCamera = GetComponent<Camera>();
        }

        if (CurrentCamera != null)
        {
            CurrentCamera.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && CurrentCamera != null)
        {
            CurrentCamera.enabled = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && CurrentCamera != null)
        {
            CurrentCamera.enabled = false; 
        }
    }
}
