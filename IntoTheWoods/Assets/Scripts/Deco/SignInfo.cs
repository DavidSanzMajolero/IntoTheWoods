using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignInfo : MonoBehaviour
{
    private bool isPlayerInRange = false;

    public GameObject arrow;

    public string text = "";
    GameManager gameManager;

    BasicSignInteraction basicSignInteraction;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.O))
        {
            Destroy(arrow);
            basicSignInteraction = GetComponent<BasicSignInteraction>();
            if (basicSignInteraction != null)
            {
                Time.timeScale = 0;  // Pausar el tiempo cuando comienza el diálogo
                basicSignInteraction.Interaction();
            }
            else
            {
                Debug.LogError("BasicSignInteraction component not found.");
            }
        }

        // Reanudar el tiempo al presionar 'X' para cerrar el diálogo
        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.X))
        {
            basicSignInteraction = null;
            gameManager.HideText();  // Esto ahora reanuda el tiempo automáticamente
        }
    }
}
