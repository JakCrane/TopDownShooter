using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManip : MonoBehaviour
{
    bool stunned = false;
    Rigidbody2D rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void InitiateKnockBack(float magnitude, float duration, Vector3 direction)
    {
        stunned = true;
        StartCoroutine(KnockBack(magnitude, duration, direction));
    }

    IEnumerator KnockBack(float magnitude, float duration, Vector3 direction)
    {
        Debug.Log("Knocking back");
        rigidBody.AddForce(direction * magnitude, ForceMode2D.Impulse); // Also affected by how much linear drag is on the gameObject.
        yield return new WaitForSeconds(duration);
        stunned = false;
    }

    public bool IsStunned()
    {
        return stunned;
    }

    void Update() 
    {
        Debug.Log(stunned);
    }
}
