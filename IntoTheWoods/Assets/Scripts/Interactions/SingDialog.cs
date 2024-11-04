using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingDialog : BasicSignInteraction
{
    public string[] dialog;
    public int dialogCounter;
    GameManager gameManager;
    public string nameChar;
    public Sprite[] iconCharArray; // Array de sprites para cada diálogo

    public void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    public override bool Interaction()
    {
        bool success = false;

        NextDialog();

        return success;
    }

    private void NextDialog()
    {
        if (dialogCounter == dialog.Length)
        {
            EndDialog();
        }
        else
        {
            // Cambiar el texto y el sprite
            gameManager.ShowText(dialog[dialogCounter], nameChar, iconCharArray[dialogCounter]);
            dialogCounter++;
        }
    }

    private void EndDialog()
    {
        gameManager.HideText();
        dialogCounter = 0;
    }
}
