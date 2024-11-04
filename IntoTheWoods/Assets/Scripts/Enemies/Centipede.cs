using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centipede : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform floorController;
    [SerializeField] private float distance;
    [SerializeField] private bool rightMovement;
    private Rigidbody2D rb;

    private GameObject Player;
    public float range = 6f;
    private float lastShoot;
    private Animator Animator;
    [SerializeField] private int health = 10;
    private bool isHurt = false;




    private void Start()
    {
        Animator = GetComponent<Animator>();
        Player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Player == null || isHurt)
        {
            return;
        }

        float distancePlayer = Mathf.Abs(Player.transform.position.x - transform.position.x);

        if (distancePlayer < range && Time.time > lastShoot + 0.25f)
        {
            Attack();
            lastShoot = Time.time;
        }
        else if (distancePlayer > range)
        {
            Animator.SetBool("attack", false);
        }



        RaycastHit2D floorInfo = Physics2D.Raycast(floorController.position, Vector2.down, distance);
        rb.velocity = new Vector2(speed, rb.velocity.y);
        if (floorInfo == false)
        {
            Rotate();
        }
    }
    private void Rotate()
    {
        rightMovement = !rightMovement;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        speed *= -1;
    }

    private void Attack()
    {
        Animator.SetBool("attack", true);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(floorController.position, floorController.transform.position + Vector3.down * distance);
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
