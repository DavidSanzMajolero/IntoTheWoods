using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private LeverMovingPlat movingPlatformUp;
    private bool playerInRange = false;
    public Sprite leverActive;

    private void Start()
    {
        movingPlatformUp = FindObjectOfType<LeverMovingPlat>();
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.O))
        {
            movingPlatformUp.shouldMove = true;
            GetComponent<SpriteRenderer>().sprite = leverActive;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
