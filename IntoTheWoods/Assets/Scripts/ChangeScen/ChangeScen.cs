using System.Collections;
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
                string currentSceneName = SceneManager.GetActiveScene().name;
                GameManager.Instance.SetLastScene(currentSceneName);

                // Configura si el jugador va hacia atrás o hacia adelante
                GameManager.Instance.SetGoBack(goBack);

                if (goBack)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                else
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                playerIsAtDoor = true;
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
            string currentSceneName = SceneManager.GetActiveScene().name;
            GameManager.Instance.SetLastScene(currentSceneName);

            GameManager.Instance.SetGoBack(goBack);

            if (goBack)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
