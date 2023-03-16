using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlatformOperator : MonoBehaviour
{
    private bool gameOn = true;
    public bool roundOn = false;
    private bool gameWinner = false;
    public float timerVal;
    public int lastBlock;

    public GameObject P1;
    public GameObject P2;
    public GameObject gameCamera;

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
    private void FixedUpdate()
    {
        if (!(roundOn) && gameOn)
        {
            startNewRound();
        }
        if (P1.transform.position.y < 0)
        {
            gameWinner = false;
            activateEndScreen();
        }
        else if (P2.transform.position.y < 0)
        {
            gameWinner = true;
            activateEndScreen();
        }
    }
    void activateEndScreen()
    {
        if (gameWinner)
        {
            gameCamera.transform.Find("Player1WinScreen").gameObject.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            gameCamera.transform.Find("Player2WinScreen").gameObject.GetComponent<Renderer>().enabled = true;
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
        timerVal *= .8f;
    }
    private void choosePlatform()
    {
        int block;
        while (true)
        {
            block = getRandNum();
            print(block);
            if (block != lastBlock)
            {
                break;
            }
        }
        if (block == 1)
        {
            lastBlock = 1;
            chosenBlock = BL;
            chosenLight = lightsBL;
        }
        else if(block == 2)
        {
            lastBlock = 2;
            chosenBlock = BR;
            chosenLight = lightsBR;
        }
        else if (block == 3)
        {
            lastBlock = 3;
            chosenBlock = TL;
            chosenLight = lightsTL;
        }
        else if (block == 4)
        {
            lastBlock = 4;
            chosenBlock = TR;
            chosenLight = lightsTR;
        } 
    }
    private int getRandNum()
    {
        return (UnityEngine.Random.Range(1, 5));
    }
    private void activateLight()
    {
        lightsBL.GetComponent<Renderer>().enabled = false;
        lightsBR.GetComponent<Renderer>().enabled = false;
        lightsTL.GetComponent<Renderer>().enabled = false;
        lightsTR.GetComponent<Renderer>().enabled = false;
        chosenLight.GetComponent<Renderer>().enabled = true;
    }
    private void activateBlock()
    {
        lowerBlock(BL);
        lowerBlock(BR);
        lowerBlock(TL);
        lowerBlock(TR);

        raiseBlock(chosenBlock);
        Invoke("raiseAllBlocks", 3);
    }
    private void lowerBlock(GameObject block)
    {
        block.transform.position = new Vector3(block.transform.position.x, -7, block.transform.position.z);
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
        roundOn = false;
    }

}
