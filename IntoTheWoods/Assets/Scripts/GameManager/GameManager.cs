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

    public GameObject player;
    public float totalPoints;

    public List<string> loadedScenes = new List<string>();

    public string lastScene;

    public bool goBack = false; // Indicador para saber si se vuelve atr�s

    public float TotalPoints { get { return totalPoints; } }

    private void Awake()
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

    public bool IsSceneLoaded(string sceneName)
    {
        return loadedScenes.Contains(sceneName);
    }

    public void AddLoadedScene(string sceneName)
    {
        if (!loadedScenes.Contains(sceneName))
        {
            loadedScenes.Add(sceneName);
        }
    }

    public void SetLastScene(string sceneName)
    {
        lastScene = sceneName;
    }

    public string GetLastScene()
    {
        return lastScene;
    }

    // Nuevo m�todo para configurar la direcci�n
    public void SetGoBack(bool isGoingBack)
    {
        goBack = isGoingBack;
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
            Debug.LogError("GameManager: Uno o m�s componentes de la UI no est�n asignados.");
            return;
        }

        dialogBox.SetActive(true);
        dialogText.text = text;
        icon.sprite = iconChar;
        characterName.text = nameChar;
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Pause");
        }
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

        Time.timeScale = 1;
    }
}
