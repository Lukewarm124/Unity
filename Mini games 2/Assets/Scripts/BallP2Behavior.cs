using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallP2Behavior : MonoBehaviour
{
    public GameObject ball;
    public GameObject rider;
    public float x_movement;
    public float z_movement;
    public float speed;
    public float x_speed;
    public float z_speed;
    public Rigidbody playerBody;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rider.transform.position = new Vector3(0, 3.5f, 0) + ball.transform.position;
        rider.transform.rotation = new Quaternion(0, 0, 0, 1);

        x_movement = Input.GetAxis("P2H");
        z_movement = Input.GetAxis("P2V");
    }
    private void FixedUpdate()
    {
        playerBody.velocity += new Vector3(x_movement * speed * x_speed, 0, z_movement * speed * z_speed);
    }
}
