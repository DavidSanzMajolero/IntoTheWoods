using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPivot : MonoBehaviour
{
    private bool rotated = false;
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("BringerOfDeath") == null && !rotated)
        {
            StartCoroutine(RotateMe(Vector3.forward * -90, 3));
            rotated = true;
        }
    }

    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
    }

}
