using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BombOperator : MonoBehaviour
{
    public GameObject gameCamera;
    private bool gameState = false;
    public GameObject P1;
    public GameObject P2;
    public GameObject Bomb1;
    private GameObject button1;
    public GameObject Bomb2;
    private GameObject button2;
    public GameObject Bomb3;
    private GameObject button3;
    public GameObject Bomb4;
    private GameObject button4;
    private bool explode_rest = true;
    public int real_bomb;

    private void Start()
    {
        real_bomb = UnityEngine.Random.Range(1, 4);
        button1 = ((Bomb1.transform.Find("Button").gameObject).transform.Find("Hitbox").gameObject);
        button2 = ((Bomb2.transform.Find("Button").gameObject).transform.Find("Hitbox").gameObject);
        button3 = ((Bomb3.transform.Find("Button").gameObject).transform.Find("Hitbox").gameObject);
        button4 = ((Bomb4.transform.Find("Button").gameObject).transform.Find("Hitbox").gameObject);
        //print(button1);
        //print(button2);
        //print(button3);
        //print(button4);
        print(real_bomb);
    }
    void Update()
    {
        if (button1.GetComponent<ButtonPressScript>().pressed && explode_rest)
        {
            explode_rest= false;
            explodeBomb(1, Bomb1);
        }
        if (button2.GetComponent<ButtonPressScript>().pressed && explode_rest)
        {
            explode_rest = false;
            explodeBomb(2, Bomb2);
        }
        if (button3.GetComponent<ButtonPressScript>().pressed && explode_rest)
        {
            explode_rest = false;
            explodeBomb(3, Bomb3);
        }
        if (button4.GetComponent<ButtonPressScript>().pressed && explode_rest)
        {
            explode_rest = false;
            explodeBomb(4 , Bomb4);
        }
    }
    void explodeBomb(int bomb,GameObject bombBody)
    {
        if(bomb == real_bomb)
        {
            print("Explode!!");
            endGame(bombBody);
        }
        else
        {
            print("no explode");
            swapPosition();
            bombBody.transform.position = new Vector3(100, 100, 100);
        }
    }
    void swapPosition()
    {
        print("Swaping position");
        if(gameState)
        {
            P1.transform.position = new Vector3(0, 7, 18);
            P2.transform.position = new Vector3(0, 1.5f, 5);
            gameState = false;
        }
        else
        {
            P1.transform.position = new Vector3(0, 1.5f, 5);
            P2.transform.position = new Vector3(0, 7, 18);
            gameState = true;
        }
        Invoke("setExplodeRest",2);
    }
    void setExplodeRest()
    {
        explode_rest = true;
    }
    void activateEndScreen()
    {
        if(gameState)
        {
            gameCamera.transform.Find("Player1WinScreen").gameObject.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            gameCamera.transform.Find("Player2WinScreen").gameObject.GetComponent<Renderer>().enabled = true;
        }
    }
    void endGame(GameObject bombBody)
    {
        print("end of game");
        bombBody.gameObject.transform.Find("Explosion").transform.localScale = new Vector3(20,20,20);
        Invoke("activateEndScreen",.5f);
        Invoke("goToWheel", 2.5f);
    }
    private void goToWheel()
    {
        SceneManager.LoadScene(0);
    }

}
