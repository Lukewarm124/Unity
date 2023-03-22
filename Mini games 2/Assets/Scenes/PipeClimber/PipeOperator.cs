using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeOperator : MonoBehaviour
{
    public GameObject pipeSegment;
    public GameObject P1PipeSpawner;
    public GameObject P2PipeSpawner;

    public GameObject rock;
    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject arrow3;
    public GameObject arrow4;

    public GameObject rockSpawner1;
    public GameObject rockSpawner2;
    public GameObject rockSpawner3;
    public GameObject rockSpawner4;

    public float pipeSpawnerTimer;
    private bool pipeActive = true;

    public float rockSpawnTimer;
    private float runningRockSpawnTimer;
    private bool rockDrop = true;
    private bool P1Rock;
    private bool P2Rock;


    void Start()
    {
        runningRockSpawnTimer = rockSpawnTimer;
    }
    void Update()
    {
        runningRockSpawnTimer -= Time.deltaTime;
        if (pipeActive)
        {
            Invoke("spawnPipe", pipeSpawnerTimer);
            pipeActive = false;
        }
        if (runningRockSpawnTimer < 0)
        {
            runningRockSpawnTimer = rockSpawnTimer;
            rockSpawnTimer *= .4f;
            prepRock();
        }
        
    }
    private void spawnPipe()
    {
        Instantiate(pipeSegment, P1PipeSpawner.transform);
        Instantiate(pipeSegment, P2PipeSpawner.transform);
        pipeActive= true;
    }
    private void prepRock()
    {
        rockDrop= false;
        int P1Rock = Random.Range(0, 3);
        int P2Rock = Random.Range(0, 3);
        

        if (P1Rock < 2)
        {
            arrowOn(arrow1);
            this.P1Rock = true;
        }
        else
        {
            arrowOn(arrow2);
            this.P1Rock = false;

        }

        if ( P2Rock < 2)
        {
            arrowOn(arrow3);
            this.P2Rock = true;
        }
        else
        {
            arrowOn(arrow4);
            this.P2Rock = false;
        }
        Invoke("allArrowOff", rockSpawnTimer/5);
    }
    private void arrowOn(GameObject arrow)
    {
        foreach (Transform child in arrow.transform)
        {
            child.GetComponent<Renderer>().enabled = true;
        }
    }
    private void arrowOff(GameObject arrow)
    {
        foreach (Transform child in arrow.transform)
        {
            child.GetComponent<Renderer>().enabled = false;
        }
    }
    private void allArrowOff()
    {
        arrowOff(arrow1);
        arrowOff(arrow2);
        arrowOff(arrow3);
        arrowOff(arrow4);
        Invoke("spawnRocks", rockSpawnTimer/10);
    }
    private void spawnRocks()
    {
        if (P1Rock)
        {
            Instantiate(rock, rockSpawner1.transform);
        }
        else
        {
            Instantiate(rock, rockSpawner2.transform);
        }

        if (P2Rock)
        {
            Instantiate(rock, rockSpawner3.transform);
        }
        else
        {
            Instantiate(rock, rockSpawner4.transform);
        }
    }
}
