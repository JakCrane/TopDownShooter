using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DispStats : MonoBehaviour
{
    //health
    public TextMeshProUGUI healthText;
    GameObject player;
    Health playerHealth;

    //round
    EnemySpawner enemySpawner;
    public TextMeshProUGUI roundText;

    //score
    public TextMeshProUGUI scoreText;
    PlayerInventory playerInventory;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<Health>();
        playerInventory = player.GetComponent<PlayerInventory>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void FixedUpdate() 
    {
        int currentHealth = playerHealth.GetHealth();
        healthText.text = currentHealth.ToString();

        roundText.text = enemySpawner.GetWaveNumber().ToString();

        scoreText.text = playerInventory.GetPoints().ToString();
    }
}
