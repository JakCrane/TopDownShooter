using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [Header("Enemies")]
    [SerializeField] List<GameObject> enemyPrefabs;

    [Header("Spawning behaviour")]
    [SerializeField] float spawnInterval = 3f;
    [SerializeField] float spawnVariance = 0.5f;
    [SerializeField] float minSpawnInterval = 2f;
    [SerializeField] float maxSpawnInterval = 4f;

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public float GetSpawnInterval()
    {
        float spawnTime = Random.Range(spawnInterval - spawnVariance, spawnInterval + spawnVariance);
        return Mathf.Clamp(spawnTime, minSpawnInterval, maxSpawnInterval);
    }
}