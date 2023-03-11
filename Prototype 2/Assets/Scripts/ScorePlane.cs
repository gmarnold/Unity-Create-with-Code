using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePlane : MonoBehaviour
{
    PlayerController playerController = new PlayerController();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        int lives = playerController.GetLives() - 1;
        if (lives <= 0)
        {
            Debug.Log("Game over!");
        }
        playerController.TakeLife();
        Debug.Log("Lives = " + lives);
    }
}
