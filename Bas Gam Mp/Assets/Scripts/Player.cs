using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float x_movement;
    public float z_movement;
    private Rigidbody player_body;
    public float speed = 2;
    public Transform player_transform;
    public LayerMask candy_layer;
    public float hitbox_size = 2;




    // Start is called before the first frame update
    void Start()
    {

        player_body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Space"))
        {
            PressSpace();
        }
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PressSpace();
        }
        */
        x_movement = Input.GetAxis("Horizontal");
        z_movement = Input.GetAxis("Vertical");
        
    }

    private void FixedUpdate()
    {
        player_body.velocity = new Vector3(x_movement * speed, player_body.velocity.y, z_movement * speed);
    }



    private float min_dist;
    private GameObject closest_candy;
    private void PressSpace()
    {
        Collider[] candies = Physics.OverlapSphere(player_transform.position, hitbox_size, candy_layer);
        foreach (Collider c in candies)
        {
            float dist = Vector3.Distance(c.transform.position, transform.position);
            //print(dist);
            if (dist < min_dist)
            {
                min_dist = dist;
                closest_candy = c.gameObject;
            }
        }
        min_dist = 10;
        //print(closest_candy);//
        Destroy(closest_candy);
    }

}
