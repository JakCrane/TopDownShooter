using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float turnSpeed = 0.0025f;

    Transform target;
    Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!target) 
        {
            GetTarget(); // Get target if no target assigned.
        }
        else
        {
            RotateTowardsTarget();
        }
        
    }

    void FixedUpdate()
    {
        rigidBody.velocity = transform.up * moveSpeed;
    }

    void GetTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void RotateTowardsTarget()
    {
        Vector2 targetDirection = target.position - transform.position;
        float targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, targetAngle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, turnSpeed);
    }
}
