using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardbehavior : MonoBehaviour
{
    public float x_movement;
    public float z_movement;
    private Rigidbody player_body;
    public float speed = 2;
    public Transform player_transform;
    public string vert;
    public string horiz;




    // Start is called before the first frame update
    void Start()
    {
        player_body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        x_movement = Input.GetAxis(horiz);
        z_movement = Input.GetAxis(vert);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PressQ();
        }

    }

    private void FixedUpdate()
    {
        player_body.velocity = new Vector3(x_movement * speed, player_body.velocity.y, z_movement * speed);

    }


    private void PressQ()
    {
        speed *= 2;

    }


}
