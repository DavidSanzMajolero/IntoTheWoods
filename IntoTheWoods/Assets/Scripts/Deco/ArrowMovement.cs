using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, target.transform.position.y, transform.position.z);
    }
 

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, 0.3f) + target.transform.position.y + 1f, transform.position.z);
    }
}
