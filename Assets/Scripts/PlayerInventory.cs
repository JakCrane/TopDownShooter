using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    int points;

    void Start()
    {
        points = 0;
    }

    public int GetPoints()
    {
        return points;
    }

    public void ChangePoints(int change)
    {
        points += change;
    }
}
