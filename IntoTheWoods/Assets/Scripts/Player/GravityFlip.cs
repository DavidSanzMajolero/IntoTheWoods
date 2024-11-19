using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class GravityFlip : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private SpriteRenderer SpriteRenderer;
    private bool grounded;
    public bool isFlipped = false;

    #region
    public AudioSource gravityFlip;
    #endregion

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Verificar si está en el suelo
        grounded = Physics2D.Raycast(transform.position, -transform.up * Mathf.Sign(Rigidbody2D.gravityScale), 1.0f);

        // Cambiar gravedad al presionar la barra espaciadora
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            GravityChange();
        }
    }

    public void GravityChange()
    {
        gravityFlip.Play();

        isFlipped = !isFlipped;

        // Invertir la escala de gravedad
        Rigidbody2D.gravityScale *= -1;

        // Ajusta solo la escala en Y del SpriteRenderer para que el sprite se vea correctamente
        SpriteRenderer.transform.localScale = new Vector3(
            SpriteRenderer.transform.localScale.x,
            isFlipped ? -1f : 1f,
            SpriteRenderer.transform.localScale.z
        );

        // Asegura que la rotación del Rigidbody2D sea cero para evitar problemas de rotación
        Rigidbody2D.rotation = 0f;

        //Debug.Log("LA GRAVEDAD ES:" + isFlipped);
    }
}
