using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChooseyBitScript : MonoBehaviour
{
    public int getNextLevel()
    {
        Collider[] things = Physics.OverlapSphere(transform.position, .3f);
        for (int i = 0; i < things.Length; i++)
        {
            if (things[i].gameObject.layer == 8)
            {
                return int.Parse(things[i].name.Substring(11,12));
            }
        }
        return -1;
    }
}
