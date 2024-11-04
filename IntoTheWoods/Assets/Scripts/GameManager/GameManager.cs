using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    public Image icon;
    public TextMeshProUGUI characterName; 
    public TextMeshProUGUI coins;

    public float TotalPoints { get { return totalPoints; } }
    public float totalPoints;


    public void Awake()
    {
        
        if (GameManager.Instance == null)
        {
            GameManager.Instance = this;
            DontDestroyOnLoad(this.gameObject);  
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public void AddPoints(float entryPoints)
    {
        totalPoints += entryPoints;
    }
    public void RemovePoints(float entryPoints)
    {
        totalPoints -= entryPoints;
    }

    public void ShowText(string text, string nameChar, Sprite iconChar)
    {
        if (dialogBox == null || dialogText == null || icon == null || characterName == null)
        {
            Debug.LogError("GameManager: Uno o más componentes de la UI no están asignados.");
            return;
        }

        dialogBox.SetActive(true);
        dialogText.text = text;
        icon.sprite = iconChar;
        characterName.text = nameChar;
    }
    private void Update()
    {

    }

    public void HideText()
    {
        if (dialogBox != null)
        {
            dialogBox.SetActive(false);
        }
        if (dialogText != null)
        {
            dialogText.text = "";
        }
        if (icon != null)
        {
            icon.sprite = null;
        }
        if (characterName != null)
        {
            characterName.text = "";
        }

        // Reanudar el tiempo cuando el diálogo desaparece
        Time.timeScale = 1;
    }
}
