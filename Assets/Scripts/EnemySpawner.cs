using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float waveInterval = 3f;

    // Spawn points throughout map
    List<EnemySpawnPoint> spawnPoints = new List<EnemySpawnPoint>();
    List<EnemySpawnPoint> activeSpawnPoints = new List<EnemySpawnPoint>();

    WaveConfigSO currentWave;
    int waveNumber = 0;

    void Awake()
    {
        spawnPoints.AddRange(FindObjectsOfType<EnemySpawnPoint>());
        Debug.Log(spawnPoints.Count);
    }

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(waveInterval);

        foreach (WaveConfigSO wave in waveConfigs)
        {
            currentWave = wave;
            waveNumber++;

            for (int i = 0; i < currentWave.GetEnemyCount(); i++)
            {
                Instantiate(currentWave.GetEnemyPrefab(i),
                            ChooseActiveSpawnPoint().position,
                            Quaternion.identity,
                            transform);
                yield return new WaitForSeconds(currentWave.GetSpawnInterval());
            }
            
            yield return new WaitUntil(() => transform.childCount == 0);
        }
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    public int GetWaveNumber() // for UI
    {
        return waveNumber;
    }

    Transform ChooseActiveSpawnPoint()
    {
        activeSpawnPoints.Clear();

        foreach (EnemySpawnPoint spawnPoint in spawnPoints)
        {
            if (spawnPoint.IsActive())
            {
                activeSpawnPoints.Add(spawnPoint);
            }
        }

        int randomSpawnIndex = Random.Range(0, activeSpawnPoints.Count);
        return activeSpawnPoints[randomSpawnIndex].GetSpawnLocation();
    }
}
