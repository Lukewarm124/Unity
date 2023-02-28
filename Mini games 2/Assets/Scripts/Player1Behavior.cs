using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Behavior : MonoBehaviour
{
    public float x_movement;
    public float z_movement;
    public float speed;
    public Rigidbody playerBody;
    public LayerMask playerMask;
    void Start()
    {
    }
    void Update()
    {
        x_movement = Input.GetAxis("P1H");
        z_movement = Input.GetAxis("P1V");
    }
    private void FixedUpdate()
    {
        playerBody.velocity = new Vector3(x_movement * speed, playerBody.velocity.y, z_movement * speed);
    }
}
