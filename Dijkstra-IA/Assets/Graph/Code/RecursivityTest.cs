using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecursivityTest : MonoBehaviour
{
    void Start()
    {
        //For iteration
        int accumulator = 0;
        for (int i = 0; i <= 4; i++)
        {
            accumulator++;
        }
        Debug.Log("Accumulation " + accumulator);

        //Recursivity iteration
        Debug.Log ("Recursivity Accumulation "+ Accumulation(0));
    }
    protected int Accumulation(int value)
    {
        if (value <= 4)
        {
            return Accumulation(value + 1);
        }
        else
        {
            return value;
        }
    }
}