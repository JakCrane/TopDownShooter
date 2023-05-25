using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Shooter shooter;
    int damage;

    void Awake() 
    {
        shooter = GetComponentInParent<Shooter>();
        damage = shooter.GetDamage();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
        if (other.gameObject.tag == "Enemy")
        {
            Health enemyHealth = other.gameObject.GetComponentInParent<Health>(); // Referencing to enemy health.
            enemyHealth.TakeDamage(damage);
        }
    }
}
