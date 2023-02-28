using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medium_tree : MonoBehaviour
{
    public GameObject candies;
    public Transform button1;
    public Transform button2;
    public LayerMask layer_msk;

    // Update is called once per frame
    void Update()
    {
        //print("button 1 " + Physics.OverlapSphere(button1.position, .3f).Length);
        //print("button 2 " + Physics.OverlapSphere(button2.position, .3f).Length);

        if (((Physics.OverlapSphere(button1.position, .3f,layer_msk).Length == 4) && (Physics.OverlapSphere(button2.position, .3f,layer_msk).Length == 4)))
        {
            drop_candy();
        }
    }

    void drop_candy()
    {
        foreach(Transform candy in candies.transform)
        {
            candy.GetComponent<SphereCollider>().enabled = true;
            candy.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
