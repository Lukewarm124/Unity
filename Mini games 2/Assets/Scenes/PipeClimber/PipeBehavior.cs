using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBehavior : MonoBehaviour
{
    public float moveDist;
    private void FixedUpdate()
    {
        transform.position += new Vector3(0,moveDist,0);
        if (transform.position.y <= -10)
        {
            Destroy(transform.gameObject);
        }
    }
}
