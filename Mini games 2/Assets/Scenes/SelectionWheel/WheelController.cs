using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WheelController : MonoBehaviour
{
    private int spins = 3;
    private int nextSceneNum;
    private int wheelRotation;
    public GameObject wheel;
    public GameObject selectorBit;
    private List<int> gameList = new List<int>();
    private Boolean wheelSpinRest=true;
    private Boolean startGame=true;

    private void Start()
    {
        wheelRotation = UnityEngine.Random.Range(0, 9);
        wheelRotation = (wheelRotation * 45) + (360 * spins);

    }

    private void spinWheel()
    {
        print(wheelRotation);
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
        if(wheelSpinRest &&  wheelRotation > 0)
        {
            spinWheel();
        }
        else if(startGame && wheelRotation == 0)
        {
            startGame = false;
            selectorBit.transform.position += new Vector3(0, -5, 0);
            int nextScene = selectorBit.GetComponent<ChooseyBitScript>().getNextLevel();
            print(nextScene);
            nextSceneNum = nextScene;
            Invoke("goToNextScene", 3);
        }
    }

    void goToNextScene()
    {
        SceneManager.LoadScene(nextSceneNum);
    }

}
