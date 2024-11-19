using System.Collections;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject forwardSpawnPoint; // Punto de spawn cuando se avanza
    public GameObject backwardSpawnPoint; // Punto de spawn cuando se retrocede
    private CharachterMovement charachter;

    void Start()
    {
        charachter = FindObjectOfType<CharachterMovement>();

        if (charachter == null)
        {
            Debug.LogError("SpawnPlayer: No se encontró el objeto con el script CharachterMovement.");
            return;
        }

        string currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        Vector3 spawnPosition;

        // Verifica si el jugador ha ido hacia atrás o hacia adelante
        if (GameManager.Instance.goBack)
        {
            spawnPosition = backwardSpawnPoint.transform.position;
        }
        else
        {
            spawnPosition = forwardSpawnPoint.transform.position;
        }

        // Aplica la posición de spawn correspondiente
        charachter.transform.position = spawnPosition;

        // Marca la escena como cargada
        if (!GameManager.Instance.IsSceneLoaded(currentSceneName))
        {
            GameManager.Instance.AddLoadedScene(currentSceneName);
        }
    }
}
