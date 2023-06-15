using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon", fileName = "New Weapon")]
public class WeaponSO : ScriptableObject
{
    [Header ("Weapon properties")]
    public string weaponName;
    public bool automatic = true;
    public int ammoCapacity = 30;
    public float reloadTime = 1f;
    public int roundsPerMinute = 360;
    public float spread = 0f;
    public int damage = 10;
    public float projectileVelocity = 20f;
    public float projectileVelocityVariance = 0f; // for shotguns and other multi projectile weapons
    public int projectilesPerShot = 1;
    public float range = 100f;

    [Header ("Weapon visuals")]
    public GameObject projectilePrefab;
    public Vector3 projectileSize = new Vector3 (1f, 1f, 1f);
}
