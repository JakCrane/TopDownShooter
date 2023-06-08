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

    bool isInteracting;

    void Start() 
    {
        rigidBody = GetComponent<Rigidbody2D>();
        moveManip = GetComponent<MovementManip>();
    }

    void Update()
    {
        GetPlayerInputs();
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

    void GetPlayerInputs()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.F))
        {
            isInteracting = true;
        }
        else
        {
            isInteracting = false;
        }
    }

    public bool IsInteracting()
    {
        return isInteracting;
    }
}
