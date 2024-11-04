using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    CharachterMovement charachter;

    void Start()
    {
        charachter = FindObjectOfType<CharachterMovement>();
        if (charachter == null)
        {
            Debug.LogError("SpawnPlayer: No se encontró el objeto con el script CharachterMovement.");
        }
        else
        {
            charachter.transform.position = transform.position;
        }

    }


}
