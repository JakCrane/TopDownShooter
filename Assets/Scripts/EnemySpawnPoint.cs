using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    int playersPresent = 0;
    [SerializeField] Transform spawnLocation;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playersPresent++;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playersPresent--;
        }
    }

    public bool IsActive()
    {
        if (playersPresent > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Transform GetSpawnLocation()
    {
        return spawnLocation;
    }
}
