using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Transform shotOrigin;
    [SerializeField] WeaponSO weapon; // All characteristics, such as damage, projectile velocity, etc. is handled by the weapon scriptable object.

    bool shooting = false;

    // void Start()
    // {
    //     // int ammo = weapon.ammoCapacity;
    // }

    void Update()
    {
        if (weapon.automatic)
        {
            if (shooting == false && Input.GetButton("Fire1"))
            {
                StartCoroutine(Shoot());
            }
        }
        else
        {
            if (shooting == false && Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(Shoot());
            }
        }
    }
    
    IEnumerator Shoot()
    {
        shooting = true; // Prevents coroutine being called again while it's already fired a bullet.

        for (int i = 0; i < weapon.projectilesPerShot; i++) // Instantiates multiple projectiles if weapon.projectilesPerShot > 1, allowing for shotguns
        {
            InstantiateProjectile();
        }

        float roundsPerSecond = weapon.roundsPerMinute / 60;
        yield return new WaitForSeconds(1 / roundsPerSecond);
        shooting = false;
    }

    void InstantiateProjectile()
    {
        GameObject projectile = Instantiate(weapon.projectilePrefab, shotOrigin.position, shotOrigin.rotation, transform); // Instantiate AS CHILD of shooter.
        Rigidbody2D projectileRigidBody = projectile.GetComponent<Rigidbody2D>();
        projectileRigidBody.transform.Rotate(new Vector3 (0f, 0f, Random.Range(-weapon.spread, weapon.spread))); // Applies spread
        projectileRigidBody.transform.localScale = weapon.projectileSize;
        projectileRigidBody.AddForce(projectileRigidBody.transform.up * Random.Range(weapon.projectileVelocity - weapon.projectileVelocityVariance, weapon.projectileVelocity + weapon.projectileVelocityVariance),
                                    ForceMode2D.Impulse);
        
        float projectileLifeTime = weapon.range / weapon.projectileVelocity;
        Destroy(projectile, projectileLifeTime);
    }

    public int GetDamage()
    {
        return weapon.damage;
    }
}
