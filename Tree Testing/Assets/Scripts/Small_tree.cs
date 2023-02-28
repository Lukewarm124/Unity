using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Small_tree : MonoBehaviour
{
    public GameObject candies;
    public Transform button1;
    void Update()
    {
        if (check_button(button1))
        {
            drop_candy();
        }
    }

    private bool check_button(Transform button_transfrom)
    {
        return (Physics.OverlapSphere(button_transfrom.position, .3f).Length == 4);
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
