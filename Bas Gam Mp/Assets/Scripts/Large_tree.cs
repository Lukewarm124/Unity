using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Large_tree : MonoBehaviour
{
    public GameObject candies;
    public Transform button1;
    public Transform button2;
    public Transform button3;
    public LayerMask layer_msk;

    void Update()
    {
        if ((check_button(button1) && check_button(button2) && check_button(button3)))
        {
            drop_candy();
        }
    }

    private bool check_button(Transform button_transfrom)
    {
        return (Physics.OverlapSphere(button_transfrom.position, .3f, layer_msk).Length == 4);
    }
    void drop_candy()
    {
        foreach (Transform candy in candies.transform)
        {
            candy.GetComponent<SphereCollider>().enabled = true;
            candy.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
