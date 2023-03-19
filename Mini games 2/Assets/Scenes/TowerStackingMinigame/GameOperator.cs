using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Runtime.CompilerServices;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameOperator : MonoBehaviour
{
    public GameObject block;
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject gameCamera;
    public bool P1Press = false;
    public int blocksP1;
    public bool P2Press = false;
    public int blocksP2;
    public bool gameEnd = false;
    public float timer;

    void Update()
    {
        //camera.transform.position += new Vector3(-10, 3, 0);
        timer -= Time.deltaTime;
        if (Input.GetButtonDown("P1V") && !gameEnd)
        {
            P1Press = true;
        }
        if (Input.GetButtonDown("P2V") && !gameEnd)
        {
            P2Press = true;
        }
        if (timer<=0 && gameEnd == false)
        {
            endGame();
        }
    }
    private void FixedUpdate()
    {
        if (P1Press)
        {
            makeBlockP1();
        }
        if (P2Press)
        {
            makeBlockP2();
        }
    }
    public void endGame()
    {
        gameEnd = true;
        if (blocksP1 >= blocksP2)
        {
            gameCamera.transform.Find("Player1WinScreen").gameObject.GetComponent<Renderer>().enabled = true;
            gameCamera.transform.position += new Vector3(0, blocksP1*2, 0);
            Invoke("goToWheel", 2);
        }
        else
        {
            gameCamera.transform.Find("Player2WinScreen").gameObject.GetComponent<Renderer>().enabled = true;
            gameCamera.transform.position += new Vector3(0, blocksP2*2, 0);
            Invoke("goToWheel", 2);
        }
       
    }
    
    private void makeBlockP1()
    {
        Instantiate(block, spawner1.transform);
        blocksP1++;
        P1Press = false;
    }
    private void makeBlockP2()
    {
        Instantiate(block, spawner2.transform);
        blocksP2++;
        P2Press = false;
    }
    private void goToWheel()
    {
        SceneManager.LoadScene(0);
    }

}
