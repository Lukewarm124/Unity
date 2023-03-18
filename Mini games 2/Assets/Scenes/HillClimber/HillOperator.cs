using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HillOperator : MonoBehaviour
{
    public GameObject gameCamera;
    public GameObject boulder;
    public float gameTimer;
    private float activeTimer;

    private void Start()
    {
        activeTimer = gameTimer;
    }
    void Update()
    {
       activeTimer -= Time.deltaTime;
        if (activeTimer < 0)
        {
            activeTimer = gameTimer;
            spawnBoulder();
        }

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

    private void spawnBoulder()
    {
        int randPos = Random.Range(-16, 16);
        Instantiate(boulder,transform.position + new Vector3(randPos,12,-5),transform.rotation);
    }
}
