using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactable : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI interactText;
    [SerializeField] int interactCost = 500;
    [SerializeField] string displayText; // Text to be displayed in game.

    PlayerMovement presentPlayer;
    PlayerInventory presentPlayerInventory;

    void Start()
    {
        if (displayText != null)
        {
            displayText = displayText + " (Costs " + interactCost + " points)";
        }
        else if (gameObject.tag == "Gate")
        {
            displayText = "Press F to unlock gate (Costs " + interactCost + " points)";
        }
    }

    void Update()
    {
        if (presentPlayer != null && interactText != null)
        {
            DisplayInteractText();
            if (presentPlayer.IsInteracting() && presentPlayerInventory.GetPoints() >= interactCost)
            {
                Interact();
            }
        }
        else
        {
            Interactable[] interactables = FindObjectsOfType<Interactable>();
            int interactablesInteracting = 0;

            foreach (Interactable i in interactables)
            {
                if (i.PlayerPresent())
                {
                    interactablesInteracting++;
                }

                if (interactablesInteracting == 0)
                {
                    HideInteractText();
                }  
            }
        }
    }

    void Interact()
    {
        if (gameObject.tag == "Gate")
        {
            presentPlayerInventory.ChangePoints(-interactCost);
            Destroy(gameObject);
            HideInteractText();
        }
    }

    void DisplayInteractText()
    {
        interactText.text = displayText.ToString();
        interactText.gameObject.SetActive(true);
    }

    void HideInteractText()
    {
        interactText.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            presentPlayer = other.GetComponent<PlayerMovement>();
            presentPlayerInventory = other.GetComponent<PlayerInventory>();
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            presentPlayer = null;
        }
    }

    public bool PlayerPresent()
    {
        if (presentPlayer != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
