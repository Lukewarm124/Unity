using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChooseyBitScript : MonoBehaviour
{
    public int getNextLevel()
    {
        Collider[] things = Physics.OverlapSphere(transform.position, 1);
        for (int i = 0; i < things.Length; i++)
        {
            if (things[i].gameObject.layer == 8)
            {
                //print(things[i]);
                return int.Parse(things[i].gameObject.name.Substring(12,1));
            }
        }
        return -1;
    }
}
