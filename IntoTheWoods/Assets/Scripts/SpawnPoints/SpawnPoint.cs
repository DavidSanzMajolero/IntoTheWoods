using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    GameManager gameManager;
    CharachterMovement charachterMovement;
    private void Awake()
    {
        charachterMovement = FindObjectOfType<CharachterMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            charachterMovement.UpdateCheckpoint(transform.position);
        }
    }
}
