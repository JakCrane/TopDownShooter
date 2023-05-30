using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float turnSpeed = 0.0025f;

    bool stunned = false;
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
        if (!stunned)
        {
            MoveForward();
        }
    }

    void MoveForward()
    {
        rigidBody.velocity = transform.up * moveSpeed * Time.fixedDeltaTime;
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

    public void InitiateKnockBack(float knockBackAmount, float knockBackDuration, Vector2 knockBackDirection)
    {
        StartCoroutine(KnockBack(knockBackAmount, knockBackDuration, knockBackDirection));
    }

    IEnumerator KnockBack(float knockBackAmount, float knockBackDuration, Vector2 knockBackDirection)
    {
        stunned = true;
        rigidBody.AddForce(knockBackDirection * knockBackAmount * Time.deltaTime, ForceMode2D.Impulse); // Also affected by how much linear drag is on the gameObject.
        yield return new WaitForSeconds(knockBackDuration);
        stunned = false;
    }
}
