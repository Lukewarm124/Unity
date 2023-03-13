using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformOperator : MonoBehaviour
{
    private bool gameOn = true;
    public GameObject BL;
    public GameObject BR;
    public GameObject TL;
    public GameObject TR;

    void Update()
    {

    }

    private void activateBlock(GameObject block)
    {
        block.transform.position = new Vector3(block.transform.position.x,0,block.transform.position.z);
    }

}
