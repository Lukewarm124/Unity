using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WheelController : MonoBehaviour
{
    private int spins = 3;
    private int wheelRotation;
    public GameObject wheel;
    public GameObject selectorBit;
    private List<int> gameList = new List<int>();
    private Boolean wheelSpinRest=true;
    private Boolean startGame=true;
    public static int chosenMinigame;
    public GameObject tutorialScreen;
    public static bool tutShown = false;

    private void Start()
    {
        if (!tutShown)
        {
            tutorialScreen.GetComponent<Renderer>().enabled = true;
            Invoke("activateWheel", 15);
        }
        else
        {
            activateWheel();
        }
    }



    private void activateWheel()
    {
        tutShown = true;
        tutorialScreen.GetComponent<Renderer>().enabled = false;
        wheelRotation = UnityEngine.Random.Range(0, 9);
        wheelRotation = (wheelRotation * 45) + (360 * spins);
    }
    private void spinWheel()
    {
        //print(wheelRotation);
        wheelSpinRest = false;
        wheel.transform.Rotate(0, 0, 5);
        wheelRotation -= 5;
        Invoke("wheelSpinRestTrue", .01f);
    }
    private void wheelSpinRestTrue()
    {
        wheelSpinRest = true;
    }
    void FixedUpdate()
    {
        //print(name.Substring(0, 12));
        if(wheelSpinRest &&  wheelRotation > 0 && tutShown)
        {
            spinWheel();
        }
        else if(startGame && wheelRotation == 0 && tutShown)
        {
            startGame = false;
            selectorBit.transform.position += new Vector3(0, -5, 0);
            int nextScene = selectorBit.GetComponent<ChooseyBitScript>().getNextLevel();
            //print(nextScene);
            chosenMinigame = nextScene+1;
            Invoke("goToNextScene", 3);
        }
    }

    void goToNextScene()
    {
        SceneManager.LoadScene(1);
    }

}
