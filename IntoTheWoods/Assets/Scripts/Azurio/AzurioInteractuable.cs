using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class AzurioInteractuable : MonoBehaviour
{
    private bool isPlayerInRange = false;

    public GameObject arrow;

    private void Start()
    {
        arrow.SetActive(false);
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
        if (GameObject.FindGameObjectWithTag("BringerOfDeath") == null)
        {
            StartCoroutine(ActivateArrow());
        }
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    IEnumerator ActivateArrow()
    {
        yield return new WaitForSeconds(2.5f);
        arrow.SetActive(true);
    }
}
