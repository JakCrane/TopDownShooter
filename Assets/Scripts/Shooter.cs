using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Transform shotOrigin;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileVelocity;
    [SerializeField] int damage = 20;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    
    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, shotOrigin.position, shotOrigin.rotation, transform); // Instantiate AS CHILD of shooter.
        Rigidbody2D projectileRigidBody = projectile.GetComponent<Rigidbody2D>();
        projectileRigidBody.AddForce(shotOrigin.up * projectileVelocity, ForceMode2D.Impulse);
        
        Destroy(projectile, 3f);
    }

    public int GetDamage()
    {
        return damage;
    }
}
