using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Private variables
    private float speed = 25;
    private float xRange = 15;
    private float topBound = 17;
    private float lowerBound = -1.5f;
    public int lives = 3;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Lives = 3");
        Debug.Log("Score = 0");
    }

    // Update is called once per frame
    void Update()
    {
        // Setting left bound
        SetBoundLeft(-xRange);

        // Setting right bound
        SetBoundRight(xRange);

        SetBoundTop(topBound);

        SetBoundBottom(lowerBound);

        // Getting the user horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");

        // Getting the user vertical input
        float verticalInput = Input.GetAxis("Vertical");

        // Allowing the player to move left and right and forward and backward
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launch a projectile from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

    }

    void SetBoundLeft(float bound)
    {
        if (transform.position.x < bound)
        {
            transform.position = new Vector3(bound, transform.position.y, transform.position.z);
        }
    }

    void SetBoundRight(float bound)
    {
        if (transform.position.x > bound)
        {
            transform.position = new Vector3(bound, transform.position.y, transform.position.z);
        }
    }

    void SetBoundTop(float bound)
    {
        if (transform.position.z > bound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, bound);
        }
    }

    void SetBoundBottom(float bound)
    {
        if (transform.position.z < bound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,bound);
        }
    }

    public int GetLives()
    {
        return lives;
    }

    public void TakeLife()
    {
        lives--;
    }

    void OnTriggerEnter(Collider other)
    {
        int lives = GetLives() - 1;
        if (lives <= 0)
        {
            Debug.Log("Game over!");
        }
        TakeLife();
        Debug.Log("Lives = " + lives);
    }


}
