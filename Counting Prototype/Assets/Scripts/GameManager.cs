using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Private variables
    private int spawnWait = 2;
    private int spawnRate = 2;
    
    private int verticalSpawnBound = 13;
    private int bottomSpawnBound = 17;
    private int spawnHeight = 8;
    private int xPos = 0;
    private int spawnSize = 1;

    // Public variables
    public bool gameOver;

    public GameObject[] ingredients;
    public GameObject titleScreen;
    public GameObject gameOverScreen;

    public void StartGame(float difficulty)
    {
        // Deactivating title screen and repeatedly spawning objects
        titleScreen.SetActive(false);
        gameOver = false;
        InvokeRepeating("SpawnIngredient", spawnWait, spawnRate - difficulty);
    }

    void SpawnIngredient()
    {
        // If game is not over, spawn random ball in random position
        if (!gameOver)
        {
            int spawnIndex = Random.Range(0, ingredients.Length);
            Instantiate(ingredients[spawnIndex], GeneratePosition(), ingredients[spawnIndex].transform.rotation);
        }
    }

    Vector3 GeneratePosition()
    {
        // Generate random y position and x position within bounds
        int zPos = Random.Range(-verticalSpawnBound, verticalSpawnBound); // Generate z so that the floating objects spawn at varying distances from the player
        int yPos = Random.Range(bottomSpawnBound, bottomSpawnBound + spawnHeight);

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

    public void GameOver()
    {
        // Show the game over screen on game over
        gameOver = true;
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        // Reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
