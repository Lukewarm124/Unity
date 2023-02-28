using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombOperator : MonoBehaviour
{
    private bool gameState = true;
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
    public int real_bomb;

    private void Start()
    {
        real_bomb = Random.Range(1, 4);
        button1 = ((Bomb1.transform.Find("Button").gameObject).transform.Find("Hitbox").gameObject);
        button2 = ((Bomb2.transform.Find("Button").gameObject).transform.Find("Hitbox").gameObject);
        button3 = ((Bomb3.transform.Find("Button").gameObject).transform.Find("Hitbox").gameObject);
        button4 = ((Bomb4.transform.Find("Button").gameObject).transform.Find("Hitbox").gameObject);
        //print(button1);
        //print(button2);
        //print(button3);
        //print(button4);
        //print(real_bomb);
    }
    void Update()
    {
        if (button1.GetComponent<ButtonPressScript>().pressed && real_bomb==1)
        {
            print("1 good");
        }
        if (button2.GetComponent<ButtonPressScript>().pressed && real_bomb == 2)
        {   
            print("2 good");
        }
        if (button3.GetComponent<ButtonPressScript>().pressed && real_bomb == 3)
        {
            print("3 good");
        }
        if (button4.GetComponent<ButtonPressScript>().pressed && real_bomb == 4)
        {
            print("4 good");
        }
    }
    
    void swapPosition()
    {
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
    }

}
