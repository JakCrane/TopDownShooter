using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float selfKnockBackAmount = 100f;
    [SerializeField] float selfKnockBackDuration = 0.5f;
    [SerializeField] float inflictedKnockBackAmount = 100f;
    [SerializeField] float inflictedKnockBackDuration = 0.5f;

    Health victimHealth;
    EnemyMovement movement;

    void Awake()
    {
        movement = GetComponent<EnemyMovement>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            victimHealth = other.gameObject.GetComponent<Health>();
            victimHealth.TakeDamage(damage);
            Debug.Log(victimHealth.GetHealth());

            movement.InitiateKnockBack(selfKnockBackAmount, selfKnockBackDuration, -transform.up); // knock back self
            PlayerMovement playerMovement = other.gameObject.GetComponent<PlayerMovement>();
            playerMovement.InitiateKnockBack(inflictedKnockBackAmount, inflictedKnockBackDuration, transform.up); // knock back player that damage was inflicted to
        }
    }
}
