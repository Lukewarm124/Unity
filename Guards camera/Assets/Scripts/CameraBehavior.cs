using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public GameObject Camera_obj;
    public GameObject G1;
    public GameObject G2;
    public GameObject Mid_point;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mid_point.transform.position = new Vector3(G1.transform.position.x + G2.transform.position.x, G1.transform.position.y + G2.transform.position.y, G1.transform.position.z + G2.transform.position.z);
        Camera_obj.transform.LookAt(Mid_point.transform);
    }
}
