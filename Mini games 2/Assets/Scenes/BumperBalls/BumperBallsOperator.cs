using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BumperBallsOperator : MonoBehaviour
{
    public GameObject outerPlatform;
    public GameObject P1;
    public GameObject P2;
    public GameObject gameCamera;
    public float timer;

    private void Update()
    {
        if (P1.transform.position.y < -2)
        {
            gameCamera.transform.Find("Player2WinScreen").gameObject.GetComponent<Renderer>().enabled = true;
            Invoke("goToWheel", 2);
        }
        if (P2.transform.position.y < -2)
        {
            gameCamera.transform.Find("Player1WinScreen").gameObject.GetComponent<Renderer>().enabled = true;
            Invoke("goToWheel", 2);
        }

        timer -= Time.deltaTime;
        if (timer<0)
        {
            lowerPlatform();
        }
    }
    private void goToWheel()
    {
        SceneManager.LoadScene(0);
    }
    private void lowerPlatform()
    {
        outerPlatform.transform.position += new Vector3(0, -.003f, 0);
    }
}
