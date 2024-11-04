using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public void MoveCamera(float cameraMoveDistance)
    {
        transform.position = new Vector3(transform.position.x + cameraMoveDistance, transform.position.y, transform.position.z);
    }

}
