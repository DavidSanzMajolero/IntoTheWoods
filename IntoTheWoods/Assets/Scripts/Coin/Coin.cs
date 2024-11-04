using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float quantityPoints;
    [SerializeField] private CoinText points;

    public float riseHeight = 2f;
    public float riseSpeed = 5f;

    private SpriteRenderer spriteRenderer;
    private bool isCollected = false; // Nueva variable para evitar sumar puntos múltiples veces

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isCollected && collision.gameObject.CompareTag("Player")) // Verificamos que no se haya recogido ya
        {
            isCollected = true; // Marcamos la moneda como recogida
            GameManager.Instance.AddPoints(quantityPoints);
            StartCoroutine(DestroyCoin());
        }
    }

    IEnumerator DestroyCoin()
    {
        Vector2 startPos = transform.position;
        Vector2 risePos = new Vector2(transform.position.x, transform.position.y + riseHeight);
        Vector2 fallPos = new Vector2(transform.position.x, transform.position.y);

        float elapsedTime = 0f;
        float totalTime = 0.5f;

        while (elapsedTime < totalTime)
        {
            float progress = elapsedTime / totalTime;
            if (progress <= 0.5f)
            {
                transform.position = Vector2.Lerp(startPos, risePos, progress * 2);
            }
            else
            {
                transform.position = Vector2.Lerp(risePos, fallPos, (progress - 0.5f) * 2);
            }

            float alpha = Mathf.Lerp(1f, 0f, progress);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, alpha);

            elapsedTime += Time.deltaTime * riseSpeed;
            yield return null;
        }

        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0f);
        transform.position = fallPos;

        Destroy(gameObject);
    }
}
