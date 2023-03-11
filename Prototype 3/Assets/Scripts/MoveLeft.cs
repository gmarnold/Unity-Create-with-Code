using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 10;
    private PlayerController playerControllerScript;
    private float leftBound = -15;


    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                playerControllerScript.AddScore(Time.deltaTime * 2);
                transform.Translate(Vector3.left * speed * 1.5f * Time.deltaTime);
            }
            else
            {
                playerControllerScript.AddScore(Time.deltaTime);
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
