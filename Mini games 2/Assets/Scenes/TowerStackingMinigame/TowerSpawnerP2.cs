using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawnerP2 : MonoBehaviour
{
    public GameObject block;
    public bool P2Press = false;
    public float blocksP2;
    public bool gameEnd = false;
    void Update()
    {
        if (Input.GetButtonDown("P2V") && !gameEnd)
        {
            P2Press = true;
        }
    }
    private void FixedUpdate()
    {
        if (P2Press)
        {
            makeBlockP1();
        }
    }
    public void endGame()
    {
        gameEnd= true;
    }
    
    private void makeBlockP1()
    {
        //Instantiate(block,transform);
        P2Press = false;
    }

}
