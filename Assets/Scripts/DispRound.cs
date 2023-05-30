using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DispRound : MonoBehaviour
{
    
    public int Value = 10;
    public TextMeshProUGUI ValueText;
    void FixedUpdate() {
        ValueText.text = Value.ToString();
    }
}
