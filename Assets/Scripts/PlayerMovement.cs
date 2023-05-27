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
    bool stunned = false;

    void Start() 
    {
        rigidBody = GetComponent<Rigidbody2D>();
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
        if (!stunned)
        {
            rigidBody.MovePosition(rigidBody.position + moveInput * moveSpeed * Time.fixedDeltaTime);
        }
        // Look towards mouse pointer
        Vector2 lookDirection = mousePosition - rigidBody.position;
        float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rigidBody.rotation = lookAngle;
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
