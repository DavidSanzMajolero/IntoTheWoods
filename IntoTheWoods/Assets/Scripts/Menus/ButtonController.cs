using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void ExitButton()
    {
        Application.Quit();
    }
    public void StartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Config()
    {
        SceneManager.LoadScene("Config");
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
