using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlatformOperator : MonoBehaviour
{
    private bool gameOn = true;
    public bool roundOn = false;
    public float timerVal;
    public GameObject lightsBL;
    public GameObject lightsBR;
    public GameObject lightsTL;
    public GameObject lightsTR;
    public GameObject BL;
    public GameObject BR;
    public GameObject TL;
    public GameObject TR;
    public GameObject chosenBlock;
    public GameObject chosenLight;

    private void Start()
    {
        startNewRound();
    }
    void FixedUpdate()
    {
        if (!(roundOn) && gameOn)
        {
            startNewRound();
        }
    }

    private void startNewRound()
    {
        roundOn= true;
        startTimer();
        choosePlatform();
        activateLight();
        Invoke("activateBlock",timerVal);
    }

    private void startTimer()
    {
        timerVal *= .3f;
    }


    private void choosePlatform()
    {
        int block = (UnityEngine.Random.Range(1,5));
        if (block == 1)
        {
            chosenBlock = BL;
            chosenLight = lightsBL;
        }
        else if(block == 2) 
        {
            chosenBlock = BR;
            chosenLight = lightsBR;
        }
        else if (block == 3)
        {
            chosenBlock = TL;
            chosenLight = lightsTL;
        }
        else if (block == 4)
        {
            chosenBlock = TR;
            chosenLight = lightsTR;
        }
        chosenBlock = null;    
    }
    private void activateLight()
    {
        lightsBL.GetComponent<Renderer>().enabled = false;
        lightsBR.GetComponent<Renderer>().enabled = false;
        lightsTL.GetComponent<Renderer>().enabled = false;
        lightsTR.GetComponent<Renderer>().enabled = false;
    }

    private void activateBlock()
    {
        lowerBlock(BL);
        lowerBlock(BR);
        lowerBlock(TL);
        lowerBlock(TR);

        raiseBlock(chosenBlock);
        Invoke("raiseAllBlocks", 2);
    }
    private void lowerBlock(GameObject block)
    {
        block.transform.position = new Vector3(block.transform.position.x, -3, block.transform.position.z);
    }
    private void raiseBlock(GameObject block)
    {
        block.transform.position = new Vector3(block.transform.position.x, 0, block.transform.position.z);
    }
    private void raiseAllBlocks()
    {
        BR.transform.position = new Vector3(BR.transform.position.x, 0, BR.transform.position.z);
        BL.transform.position = new Vector3(BL.transform.position.x, 0, BL.transform.position.z);
        TL.transform.position = new Vector3(TL.transform.position.x, 0, TL.transform.position.z);
        TR.transform.position = new Vector3(TR.transform.position.x, 0, TR.transform.position.z);

    }

}
