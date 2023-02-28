using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public GameObject block;
    public bool P1Press = false;
    public float blocksP1;
    public bool gameEnd = false;

    void Update()
    {
        if(Input.GetButtonDown("P1V") && !gameEnd)
        {
            P1Press= true;
        }
    }
    private void FixedUpdate()
    {
        if(P1Press)
        {
            makeBlockP1();
        }
    }

    public void endGame()
    {
        gameEnd = true;
    }
    private void makeBlockP1()
    {
        //Instantiate(block,transform);
        P1Press = false;
    }

}
