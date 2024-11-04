using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharachterMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 275.0f; // Ahora ajustado al valor específico

    private Animator Animator;
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;

    private bool grounded;

    private SpriteRenderer SpriteRenderer;

    public static CharachterMovement Instance;

    public GameObject BulletPrefab;
    private float lastShot;

    Vector2 checkpointPos;

    private GravityFlip gravityFlip;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        checkpointPos = transform.position;
        gravityFlip = GetComponent<GravityFlip>();
    }

    private void Awake()
    {
        if (CharachterMovement.Instance == null)
        {
            CharachterMovement.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");

        if (Horizontal < 0)
            SpriteRenderer.flipX = true;
        else if (Horizontal > 0.0f)
            SpriteRenderer.flipX = false;

        Animator.SetBool("running", Horizontal != 0.0f);

        // Detectar si está en el suelo, ajustando el raycast según la gravedad
        grounded = Physics2D.Raycast(transform.position, Vector2.down * Mathf.Sign(Rigidbody2D.gravityScale), 1.0f);

        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            Jump();
        }

        Animator.SetBool("floor", grounded);

        if (Input.GetKeyDown(KeyCode.Q) && Time.time > lastShot + 0.25f)
        {
            StartCoroutine(HandleAttack());
        }
    }

    IEnumerator HandleAttack()
    {
        Animator.SetBool("running", false);
        Animator.SetBool("attack", true);

        Shot();
        lastShot = Time.time;

        yield return new WaitForSeconds(0.2f);  // Ajusta esto según la duración de tu animación de ataque

        Animator.SetBool("attack", false);

        if (Horizontal != 0.0f)
        {
            Animator.SetBool("running", true);
        }
    }

    public void Shot()
    {
        Vector3 direction;
        if (SpriteRenderer.flipX) direction = Vector2.left;
        else direction = Vector2.right;
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletShot>().SetDirection(direction);
    }

    private void Jump()
    {
        Vector2 jumpDirection = gravityFlip.isFlipped ? Vector2.down : Vector2.up;
        Rigidbody2D.AddForce(jumpDirection * jumpForce);
        Animator.SetTrigger("jumping");
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * speed, Rigidbody2D.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Danger"))
        {
            Die();
        }

    }

    void Die()
    {
        Animator.SetBool("dead", true);
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(0.7f);

        Animator.SetBool("dead", false);
        transform.position = checkpointPos;
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        if (gravityFlip != null && gravityFlip.isFlipped)
        {
            gravityFlip.GravityChange();
        }
    }

    public void UpdateCheckpoint(Vector2 pos)
    {
        checkpointPos = pos;
    }
}
