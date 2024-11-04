using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDontDestroy : MonoBehaviour
{
    //dont destroy the canvas when changing scenes
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}
