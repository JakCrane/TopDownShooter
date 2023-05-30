using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] int damage;
    // [SerializeField] float selfKnockMagnitude = 100f;
    // [SerializeField] float selfKnockDuration = 0.5f;
    // [SerializeField] float victimKnockMagnitude = 100f;
    // [SerializeField] float victimKnockDuration = 0.5f;

    Health victimHealth;
    // MovementManip movement;
    // MovementManip victimMovement;

    void Awake()
    {
        // movement = GetComponent<MovementManip>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            // Damage victim
            victimHealth = other.gameObject.GetComponent<Health>();
            victimHealth.TakeDamage(damage);
            Debug.Log(victimHealth.GetHealth());

            // Knockback self + victim
            // movement.InitiateKnockBack(selfKnockMagnitude, selfKnockDuration, -transform.up); // knock back self
            // victimMovement = other.gameObject.GetComponent<MovementManip>();
            // victimMovement.InitiateKnockBack(victimKnockMagnitude, victimKnockDuration, transform.up); // knock back player that damage was inflicted to
        }
    }
}
