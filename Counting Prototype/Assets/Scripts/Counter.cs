using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    // Private variables
    private GameManager gameManagerScript;
    private int count = 0;
    private string colorText;
    
    // Public variables
    public Text CounterText;

    private void Start()
    {
        // Setting the default text
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        count = 0;
        colorText = CounterText.text;
        CounterText.text = colorText + count;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Checking to make sure the color matches and incrementing the associated text if so
        if (other.gameObject.CompareTag(gameObject.tag))
        {
            count += 1;
            CounterText.text = colorText + count;
        }
        else
        {
            // Otherwise it's game over
            gameManagerScript.GameOver();
        }
    }
}
