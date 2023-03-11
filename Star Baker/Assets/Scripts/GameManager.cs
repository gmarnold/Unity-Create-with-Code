using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Private variables
    private PlayerController playerControllerScript;
    private int redMeteorChance = 100;
    private int leftSpawnBound = 24;
    private int rightSpawnBound = 30;
    private int bottomSpawnBound = -2;
    private int topSpawnBound = 9;
    private int zPos = 0;
    private int spawnSize = 1;

    // Public variables
    public GameObject[] obstacles;
    public GameObject[] ingredients;
    public GameObject redMeteor;
    public GameObject stardust;
    
    public GameObject titleScreen;
    public GameObject stars;    

    public void StartGame(float difficulty)
    {
        // Remove title screen
        titleScreen.SetActive(false);
        stars.SetActive(false);

        // Start the game for the player
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        playerControllerScript.StartGame();

        // Repeatedly spawning obstacles, ingredients, and stardust
        InvokeRepeating("SpawnObstacle", 2, 1f / difficulty);
        InvokeRepeating("SpawnIngredient", 2, 1);
        InvokeRepeating("SpawnStardust", 2, 6);
    }

    void SpawnObstacle()
    {
        // Check if game is over before spawning
        if (!playerControllerScript.gameOver)
        {
            // Calculating chance that rare red meteor spawns
            int redMeteorSpawn = Random.Range(0, redMeteorChance);
            if (redMeteorSpawn == 0)
            {
                Instantiate(redMeteor, GeneratePosition(), redMeteor.transform.rotation);
            }
            else
            {
                // Otherwise spawn random obstacle at random position
                int obstacleIndex = Random.Range(0, obstacles.Length);
                Instantiate(obstacles[obstacleIndex], GeneratePosition(), obstacles[obstacleIndex].transform.rotation);
            }
        }
    }

    void SpawnIngredient()
    {
        // Check if game is over before spawning
        if (!playerControllerScript.gameOver)
        {
            // Spawn random obstacle at random position
            int ingredientIndex = Random.Range(0, ingredients.Length);
            Instantiate(ingredients[ingredientIndex], GeneratePosition(), ingredients[ingredientIndex].transform.rotation);
        }
    }

    void SpawnStardust()
    {
        // Check if game is over before spawning
        if (!playerControllerScript.gameOver)
        {
            // Spawn random obstacle at random position
            Instantiate(stardust, GeneratePosition(), stardust.transform.rotation);
        }
    }

    Vector3 GeneratePosition()
    {
        // Generate random y position and x position within bounds
        int xPos = Random.Range(leftSpawnBound, rightSpawnBound); // Generate x so that the floating objects spawn at varying distances from the player
        int yPos = Random.Range(bottomSpawnBound, topSpawnBound);

        // Create new vector with coordinates
        Vector3 pos = new Vector3(xPos, yPos, zPos);
        
        // Check if there is already an object in generated position
        if (!Physics.CheckSphere(pos, spawnSize))
        {
            // If there isn't, return this position
            return pos;
        }
        else
        {
            // If there is, recurse until you find one that is free
            return GeneratePosition();
        }
    }

    public void RestartGame()
    {
        // Reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
