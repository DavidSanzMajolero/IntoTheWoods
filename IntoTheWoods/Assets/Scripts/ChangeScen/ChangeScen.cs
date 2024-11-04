using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScen : MonoBehaviour
{
    public bool goBack = false;
    public bool needKey = false;

    private bool playerIsAtDoor = false; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!needKey)
            {
                if (goBack) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                playerIsAtDoor = true;
                //Debug.Log("You need a key to open this door");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsAtDoor = false;
        }
    }

    private void Update()
    {
        if (playerIsAtDoor && needKey && Input.GetKeyDown(KeyCode.O))
        {
            //Debug.Log("You have opened the door");
            if (goBack) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
