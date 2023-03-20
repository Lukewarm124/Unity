using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    public GameObject candy;
    public void spawnCandy()
    {
        transform.position = new Vector3(Random.Range(-25, 25), transform.position.y, Random.Range(-10, 30));
        GameObject candyObj = Instantiate(candy);
        candyObj.transform.parent = null;
        candyObj.transform.position = transform.position;
    }
}
