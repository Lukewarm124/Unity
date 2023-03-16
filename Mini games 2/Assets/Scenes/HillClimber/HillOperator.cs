using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HillOperator : MonoBehaviour
{
    public GameObject gameCamera;
    
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "P2HB")
        {
            print("p2");
            gameCamera.transform.Find("Player2WinScreen").gameObject.GetComponent<Renderer>().enabled = true;
            Invoke("goToWheel", 2);
        }
        if (other.gameObject.name == "P1HB")
        {
            print("p1");
            gameCamera.transform.Find("Player1WinScreen").gameObject.GetComponent<Renderer>().enabled = true;
            Invoke("goToWheel", 2);
        }
    }
    private void goToWheel()
    {
        SceneManager.LoadScene(0);
    }
}
