using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOperator : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;
    public GameObject gameCamera;

    public bool P1Pos;
    public bool P2Pos;

    public bool gameActive = true;

    private void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            print("a");
            movePlayer(true);
        }
        if (Input.GetKeyDown("d"))
        {
            print("d");
            movePlayer(true);
        }
        if (Input.GetKeyDown("j"))
        {
            print("j");
            movePlayer(false);
        }
        if (Input.GetKeyDown("l"))
        {
            print("l");
            movePlayer(false);
        }
    }
    private void FixedUpdate()
    {
        if (P1.transform.position.y < -6 && gameActive)
        {
            gameActive = false;
            gameCamera.transform.Find("Player2WinScreen").gameObject.GetComponent<Renderer>().enabled = true;
            Invoke("goToWheel", 2);
        }
        else if (P2.transform.position.y < -6 && gameActive)
        {
            gameActive = false;
            gameCamera.transform.Find("Player1WinScreen").gameObject.GetComponent<Renderer>().enabled = true;
            Invoke("goToWheel", 2);
        }
    }
    private void goToWheel()
    {
        SceneManager.LoadScene(0);
    }


    private void movePlayer(bool player)
    {
        if (player)
        {
            if (P1Pos)
            {
                P1.transform.position = new Vector3(-7.5f, P1.transform.position.y, 0);
                P1.GetComponent<Rigidbody>().velocity = Vector3.zero;
                P1Pos = false;
            }
            else
            {
                P1.transform.position = new Vector3(-2.5f, P1.transform.position.y, 0);
                P1.GetComponent<Rigidbody>().velocity = Vector3.zero;
                P1Pos = true;
            }
        }
        else
        {
            if (P2Pos)
            {
                P2.transform.position = new Vector3(2.5f, P2.transform.position.y, 0);
                P2.GetComponent<Rigidbody>().velocity = Vector3.zero;
                P2Pos = false;
            }
            else
            {
                P2.transform.position = new Vector3(7.5f, P2.transform.position.y, 0);
                P2.GetComponent<Rigidbody>().velocity = Vector3.zero;
                P2Pos = true;
            }
        }
    }
}
