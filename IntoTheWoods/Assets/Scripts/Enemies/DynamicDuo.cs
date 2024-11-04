using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicDuo : MonoBehaviour
{
    public GameObject BulletPrefab;
    private GameObject Player;
    private float lastShoot;
    public float range = 6f;
    public int health = 4;
    private Animator Animator;
    private bool isHurt = false;
    public float bulletSpread = 0.2f; // Control de dispersión (ajustable)

    private void Start()
    {
        Animator = GetComponent<Animator>();
        Player = GameObject.FindWithTag("Player");

        if (Player == null)
        {
            Debug.LogError("Player no encontrado. Asegúrate de que el prefab del jugador tenga el tag 'Player'.");
        }
    }

    private void Update()
    {
        if (Player == null || isHurt)
        {
            return;
        }

        float distance = Mathf.Abs(Player.transform.position.x - transform.position.x);

        if (distance < range && Time.time > lastShoot + 0.25f)
        {
            Shoot();
            lastShoot = Time.time;
        }
        else if (distance > range)
        {
            Animator.SetBool("attack", false);
        }
    }

    private void Shoot()
    {
        Animator.SetBool("attack", true);

        Vector3 direction;
        if (transform.localScale.x == 1.0f)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }

        // Añadimos la dispersión en el eje Y
        float randomSpread = Random.Range(-bulletSpread, bulletSpread); // Genera un valor aleatorio para el eje Y
        Vector3 spreadDirection = new Vector3(direction.x, randomSpread, 0); // Aplicamos el spread

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletShot>().SetDirection(spreadDirection.normalized); // Disparamos en la nueva dirección con dispersión
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            return;
        }

        StartCoroutine(HandleHurt());
    }

    private IEnumerator HandleHurt()
    {
        isHurt = true;
        Animator.SetBool("hurt", true);
        yield return new WaitForSeconds(0.5f);
        Animator.SetBool("hurt", false);
        isHurt = false;
    }
}
