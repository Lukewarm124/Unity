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
    private bool space_button_pressed;
    private bool candy_near = false;
    public Transform player_transform;
    public LayerMask candy_layer;
    public float candies = 0;
    public GameObject candy_preset;
    
    


    // Start is called before the first frame update
    void Start()
    {
        player_body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        x_movement = Input.GetAxis("Horizontal");
        z_movement = Input.GetAxis("Vertical");
        if(Input.GetKeyDown( KeyCode.Space ))
        {
            space_button_pressed = true;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PressQ();
        }
    }

    private void FixedUpdate()
    {
        player_body.velocity = new Vector3 (x_movement * speed, player_body.velocity.y, z_movement * speed);
        if (space_button_pressed)
        {
            PressSpace();
            space_button_pressed = false;
        }
        
    }

    
    
    private float min_dist;
    private GameObject closest_candy;

    private void PressQ()
    {
        if(candies>0)
        {
            Instantiate(candy_preset, transform);
            candies -= 1;
            transform.localScale += new Vector3(-.01f, -.01f, -.01f);
            speed += .01f;
        }
    }
    private void PressSpace()
    {
        Collider[] candies = Physics.OverlapSphere(player_transform.position, 1, candy_layer);
        foreach(Collider c in candies)
        {
            candy_near = true;
            float dist = Vector3.Distance(c.transform.position, transform.position);
            //print(dist);
            if (dist < min_dist)
            {
                min_dist = dist;
                closest_candy = c.gameObject;
                
            }
        }
        if(candy_near)
        {
            min_dist = 10;
            Destroy(closest_candy);
            transform.localScale += new Vector3(.01f, .01f, .01f);
            speed -= .01f;
            candy_near = false;
            this.candies += 1;
        }
        
    }

}
