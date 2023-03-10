using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    private int spins = 0;
    private int wheelRotation;
    public GameObject wheel;
    public GameObject wheelSection1;
    public GameObject wheelSection2;
    public GameObject wheelSection3;
    public GameObject wheelSection4;
    public GameObject wheelSection5;
    public GameObject wheelSection6;
    public GameObject wheelSection7;
    public GameObject wheelSection8;
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
        //print(wheelRotation);
        wheelSpinRest = false;
        wheel.transform.Rotate(0, 0, 1);
        wheelRotation -= 1;
        Invoke("wheelSpinRestTrue", .01f);
    }
    private void wheelSpinRestTrue()
    {
        wheelSpinRest=true;
    }
    void Update()
    {
        string name = "fhsjhfjsdfjsdfjs1";
        //print(name.Substring(0, 12));
        if(wheelSpinRest &&  wheelRotation > 0)
        {
            spinWheel();
        }
        else if(startGame && wheelRotation == 0)
        {
            startGame = false;
            selectorBit.transform.position += new Vector3(0, -5, 0);
            print(selectorBit.GetComponent<ChooseyBitScript>().getNextLevel());
            //Invoke("goToNextScene", 3);
        }
    }

}
