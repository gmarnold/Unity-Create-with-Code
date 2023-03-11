using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Private variables
    private PlayerController playerControllerScript;
    
    private float speed = 7;
    private float rotateSpeed = .1f;
    private int rotateBounds = 10;

    private float leftBound = -7;

    void Start()
    {
        // Find the Player script so we know when the game is over to destroy the objects
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        // Generate a random rotation vector
        Vector3 rotationVector = GenerateRotationVector();

        // Apply force and torque to object to move it left
        Rigidbody objectRb = GetComponent<Rigidbody>();
        objectRb.AddForce(Vector3.left * speed, ForceMode.Impulse);
        objectRb.AddTorque(rotationVector * rotateSpeed, ForceMode.Impulse);
    }

    void Update()
    {
        // If the game is over, destroy the object
        if (playerControllerScript.gameOver)
        {
            Destroy(gameObject);
            
        }

        // If the obstacle is out of bounds, destroy it
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }

    Vector3 GenerateRotationVector()
    {
        // Generate a random rotation vector for each object
        return new Vector3(Random.Range(-rotateBounds, rotateBounds), Random.Range(-rotateBounds, rotateBounds), Random.Range(-rotateBounds, rotateBounds));
    }
}
