using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionOperator : MonoBehaviour
{
    public GameObject wheelOp;
    private int nextGame = WheelController.chosenMinigame;

    void Update()
    {
        
    }

    private void nextMinigame()
    {
        SceneManager.LoadScene(nextGame);
    }
}
