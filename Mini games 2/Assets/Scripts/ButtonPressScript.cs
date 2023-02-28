using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressScript : MonoBehaviour
{
    public bool pressed = false;


    //When a player gets on the buttin the pressed variable becomes true
    private void OnTriggerEnter(Collider other)
    {
        //print("enter trig");
        //print(other.gameObject.layer);
        if (other.gameObject.layer == 6 || other.gameObject.layer == 7)
        {
            pressed = true;
        }
        //print(pressed);
    }

    //When a player gets off the button the pressed variable becomes false
    private void OnTriggerExit(Collider other)
    {
        //print("exit trig");
        //print(other.gameObject.layer);
        if (other.gameObject.layer == 6 || other.gameObject.layer == 7)
        {
            pressed = false;
        }
        //print(pressed);
    }
}
