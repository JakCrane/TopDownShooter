using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIPathController : MonoBehaviour
{
    MovementManip moveManip;
    AIPath path;
    float defaultSpeed;

    void Awake()
    {
        moveManip = GetComponent<MovementManip>();
        path = GetComponent<AIPath>();
        defaultSpeed = path.maxSpeed;
    }

    void Update()
    {
        if (moveManip.IsStunned())
        {
            path.maxSpeed = 0;
            path.canMove = false;
        }
        else
        {
            path.maxSpeed = defaultSpeed;
            path.canMove = true;
        }
    }
}
