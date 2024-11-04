using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public GameObject arrow;
    public float coinsNeeded = 0;
    bool isPlayerInRange = false;
    bool playerHasCoins = false;
    bool chestIsOpen = false;
    private Animator Animator;

    void Start()
    {
        Animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            playerHasCoins = CoinsNeeded();

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.O) && playerHasCoins && !chestIsOpen)
        {
            Destroy(arrow);
            chestIsOpen = true;
            GameManager.Instance.RemovePoints(coinsNeeded);
            Animator.SetBool("isOpened", chestIsOpen);
        }
    }
    bool CoinsNeeded()
    {
        return coinsNeeded <= GameManager.Instance.totalPoints;
    }

}
