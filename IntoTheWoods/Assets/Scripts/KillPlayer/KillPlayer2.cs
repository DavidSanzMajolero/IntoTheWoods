using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer2 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (currentSceneIndex > 0)
            {
                SceneManager.LoadScene(currentSceneIndex - 1);
            }
            else
            {
                Debug.LogWarning("No hay una escena anterior para cargar.");
            }
        }
    }

}
