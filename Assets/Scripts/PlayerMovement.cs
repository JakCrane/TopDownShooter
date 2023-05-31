using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Camera cam;
    
    Rigidbody2D rigidBody;
    Vector2 moveInput;
    Vector2 mousePosition;

    MovementManip moveManip;

    void Start() 
    {
        rigidBody = GetComponent<Rigidbody2D>();
        moveManip = GetComponent<MovementManip>();
    }

    void Update()
    {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        // Move in accordance with player's movement input (e.g. WASD)
        if (!moveManip.IsStunned())
        {
            rigidBody.MovePosition(rigidBody.position + moveInput * moveSpeed * Time.fixedDeltaTime);
        }
        // Look towards mouse pointer
        Vector2 lookDirection = mousePosition - rigidBody.position;
        float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rigidBody.rotation = lookAngle;
    }
}
