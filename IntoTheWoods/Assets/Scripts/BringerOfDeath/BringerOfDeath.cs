using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BringerOfDeath : MonoBehaviour
{
    private Animator animator;
    public Rigidbody2D rb2D;
    private Transform player;
    public bool facingRight = true;

    [Header("HP")]
    [SerializeField] private float health;

    [Header("Attack")]
    [SerializeField] private Transform damageController;
    [SerializeField] private float attackRange;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distance = Vector2.Distance(player.position, transform.position);
        animator.SetFloat("distancePlayer", distance);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            animator.SetTrigger("death");
            Destroy(gameObject, 1f);
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    public void LookPlayer()
    {
        if (player != null &&
            ((player.position.x > transform.position.x && !facingRight) ||
             (player.position.x < transform.position.x && facingRight)))
        {
            facingRight = !facingRight;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    public void Attack()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(damageController.position, attackRange);
        foreach (Collider2D collision in objects)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                // Cargar la escena anterior en lugar de destruir al jugador
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(damageController.position, attackRange);
    }
}
