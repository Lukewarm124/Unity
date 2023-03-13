using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlatformOperator : MonoBehaviour
{
    private bool gameOn = true;
    public float timerVal;
    public float runningTimer;
    public GameObject BL;
    public GameObject BR;
    public GameObject TL;
    public GameObject TR;

    void FixedUpdate()
    {
        if (runningTimer < 0)
        {
            timerVal -= 2;
            runningTimer = timerVal;
            activateBlock(choosePlatform());
        }
        else
        {
            runningTimer -= Time.deltaTime;
        }
    }

    private GameObject choosePlatform()
    {
        int block = (UnityEngine.Random.Range(1,5));
        if (block == 1)
        {
            return BL;
        }
        else if(block == 2) 
        { 
            return BR;
        }
        else if (block == 3)
        {
            return TL;
        }
        else if (block == 4)
        {
            return TR;
        }
        return null;    
    }

    private void activateBlock(GameObject block)
    {
        lowerBlock(block);
        raiseBlock(block);
    }
    private void lowerBlock(GameObject block)
    {
        block.transform.position = new Vector3(block.transform.position.x, -3, block.transform.position.z);
    }
    private void raiseBlock(GameObject block)
    {
        block.transform.position = new Vector3(block.transform.position.x, 0, block.transform.position.z);
    }

}
