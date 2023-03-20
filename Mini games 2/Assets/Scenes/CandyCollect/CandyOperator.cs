using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CandyOperator : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;
    public GameObject candySpawner;
    public GameObject gameCamera;

    public int P1Candy;
    public int P2Candy;
    public int amount;
    public float timer;
    public float growAmount;

    public LayerMask candyLayer;
    private bool gameActive = true;

    private void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            candySpawner.GetComponent<CandySpawner>().spawnCandy();
        }
    }
    private void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer < 0 && gameActive)
        {
            gameActive= false;
            
            if(P1Candy >= P2Candy)
            {
                gameCamera.transform.Find("Player1WinScreen").gameObject.GetComponent<Renderer>().enabled = true;
                Invoke("goToWheel", 2);
            }
            else
            {
                gameCamera.transform.Find("Player2WinScreen").gameObject.GetComponent<Renderer>().enabled = true;
                Invoke("goToWheel", 2);
            }
        }

        if (gameActive)
        {
            Collider[] candP1 = Physics.OverlapSphere(P1.transform.position, P1.transform.localScale.y + 2, candyLayer);
            Collider[] candP2 = Physics.OverlapSphere(P2.transform.position, P2.transform.localScale.y + 2, candyLayer);

            foreach (Collider c in candP1)
            {
                print(c.gameObject);
                Destroy(c.gameObject);
                P1Candy++;
                P1.transform.localScale += new Vector3(growAmount, growAmount, growAmount);
            }
            foreach (Collider c in candP2)
            {
                print(c.gameObject);
                Destroy(c.gameObject);
                P2Candy++;
                P2.transform.localScale += new Vector3(growAmount, growAmount, growAmount);
            }
        }
    }
    private void goToWheel()
    {
        SceneManager.LoadScene(0);
    }
}
