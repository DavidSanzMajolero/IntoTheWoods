using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    public float speed;
    private Vector2 direction;
    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        
    }
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = direction * speed;
    }
    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DynamicDuo dynamicDuo = collision.GetComponent<DynamicDuo>();
        Centipede centipede = collision.GetComponent<Centipede>();
        BringerOfDeath bringerOfDeath = collision.GetComponent<BringerOfDeath>();
        if (centipede != null)
        {
            centipede.TakeDamage(1);
        }
        if (dynamicDuo != null)
        {
            dynamicDuo.TakeDamage(1);
        }
        if (bringerOfDeath != null)
        {
            bringerOfDeath.TakeDamage(1);
        }

    }
}
