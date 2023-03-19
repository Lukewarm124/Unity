using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TipperOperator : MonoBehaviour
{
    public GameObject gameCamera;
    public GameObject P1;
    public GameObject P2;
    private bool spinId = true;
    public float runningSpinTimer;
    public float spinTimer;
    public float ROTTimer;
    public float runningROTTimer;

    void Update()
    {
        runningSpinTimer -= Time.deltaTime;
        runningROTTimer -= Time.deltaTime;
        if (P1.transform.position.y < -5)
        {
            gameCamera.transform.Find("Player2WinScreen").gameObject.GetComponent<Renderer>().enabled = true;
            Invoke("goToWheel", 2);
        }
        if (P2.transform.position.y < -5)
        {
            gameCamera.transform.Find("Player1WinScreen").gameObject.GetComponent<Renderer>().enabled = true;
            Invoke("goToWheel", 2);
        }

        if(runningSpinTimer < 0 && spinId)
        {
            runningSpinTimer = spinTimer;
            spinId = false;
        }
        else if(runningSpinTimer < 0 && !(spinId))
        {
            runningSpinTimer = spinTimer;
            spinId = true;
        }
    }
    private void FixedUpdate()
    {
        if (spinId && runningROTTimer<0)
        {
            runningROTTimer = ROTTimer;
            bitRight();
        }
        else if (!(spinId) && runningROTTimer < 0)
        {
            runningROTTimer = ROTTimer;
            bitLeft();
        }
    }
    private void goToWheel()
    {
        SceneManager.LoadScene(0);
    }

    private void bitRight()
    {
        transform.Rotate(0, 0, 1);
    }
    private void bitLeft()
    {
        transform.Rotate(0, 0, -1);
    }

}
