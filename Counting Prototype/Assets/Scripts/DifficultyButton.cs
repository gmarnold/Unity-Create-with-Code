using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    // Private variables
    private GameManager gameManager;
    private Button button;

    // PUblic variables
    public float difficulty;

    void Start()
    {
        // Find Game Manager object so we can start the game
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // Setting button and its Listener
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty()
    {
        // Starting the game with the chosen button's difficulty
        gameManager.StartGame(difficulty);
    }
}