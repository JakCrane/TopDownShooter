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
    public int round = 10;
    public TextMeshProUGUI roundText;
    //score
    //public TextMeshProUGUI scoreText;
    //GameObject player;
    //Health playerHealth;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<Health>();
    }
    void FixedUpdate() 
    {
        int currentHealth = playerHealth.GetHealth();
        healthText.text = currentHealth.ToString();

        roundText.text = round.ToString();
    }
}
