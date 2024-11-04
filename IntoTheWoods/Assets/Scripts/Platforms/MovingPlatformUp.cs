using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformUp : MonoBehaviour
{
    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 2;
    int direction = 1;
    public bool lerp = false;
    public bool shouldMove = true;
    private void Update()
    {
        if (shouldMove)
        {
            Vector2 target = CurrentMovementTarget();
            if (lerp)
            {
                platform.position = Vector2.Lerp(platform.position, target, speed * Time.deltaTime);

            }
            else
            {
                platform.position = Vector2.MoveTowards(platform.position, target, speed * Time.deltaTime);
            }

            float distance = (target - (Vector2)platform.position).magnitude;

            if (distance <= 0.1f)
            {
                direction *= -1;
            }
        }

    }
    Vector2 CurrentMovementTarget()
    {
        if (direction == 1)
        {
            return startPoint.position;
        }
        else
        {
            return endPoint.position;
        }
    }

    private void OnDrawGizmos()
    {
        if (platform != null && startPoint != null && endPoint != null)
        {

            Gizmos.DrawLine(platform.transform.position, startPoint.position);
            Gizmos.DrawLine(platform.transform.position, endPoint.position);
        }
    }
}
