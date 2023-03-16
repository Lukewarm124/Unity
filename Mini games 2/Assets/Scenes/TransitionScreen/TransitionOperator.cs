using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionOperator : MonoBehaviour
{
    public GameObject gameCamera;
    private int nextGame = WheelController.chosenMinigame;

    void Start()
    {
        print(nextGame);
        if (nextGame == 2)
        {
            gameCamera.transform.GetChild(2).gameObject.GetComponent<Renderer>().enabled = true;
        }
        else if (nextGame == 3)
        {
            gameCamera.transform.GetChild(3).gameObject.GetComponent<Renderer>().enabled = true;
        }
        else if (nextGame == 4)
        {
            gameCamera.transform.GetChild(4).gameObject.GetComponent<Renderer>().enabled = true;
        }
        else if (nextGame == 5)
        {
            gameCamera.transform.GetChild(5).gameObject.GetComponent<Renderer>().enabled = true;
        }
        else if (nextGame == 6)
        {
            gameCamera.transform.GetChild(6).gameObject.GetComponent<Renderer>().enabled = true;
        }
        else if (nextGame == 7)
        {
            gameCamera.transform.GetChild(7).gameObject.GetComponent<Renderer>().enabled = true;
        }
        else if (nextGame == 8)
        {
            gameCamera.transform.GetChild(8).gameObject.GetComponent<Renderer>().enabled = true;
        }
        else if (nextGame == 9)
        {
            gameCamera.transform.GetChild(9).gameObject.GetComponent<Renderer>().enabled = true;
        }
        Invoke("nextMinigame", 6);
    }

    private void nextMinigame()
    {
        SceneManager.LoadScene(nextGame);
    }
}
