using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinText : MonoBehaviour
{
    private float previousPoints = -1; // Nueva variable para almacenar el valor anterior de puntos
    public TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        // Solo actualizamos el texto si los puntos han cambiado
        if (GameManager.Instance.TotalPoints != previousPoints)
        {
            previousPoints = GameManager.Instance.TotalPoints;
            textMesh.text = previousPoints.ToString(); // Actualizamos el texto con los nuevos puntos
        }
    }
}
