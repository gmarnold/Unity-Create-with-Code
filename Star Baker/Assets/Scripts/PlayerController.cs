using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    // Private variables
    private float leftBound = -2.5f;
    private float rightBound = 19.5f;
    private float topBound = 9.5f;
    private float lowerBound = -2;
    private float speed = 15;

    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    
    private int lives = 3;
    private int score = 0;

    private int explosionTime = 2;
    private int volume = 3;
    
    private float stardustVolume = .3f;
    private bool stardustActive = false;
    private int stardustTime = 4;
    
    private bool spinning = false;
    private int pushBack = 10;
    private float spinTime = .9f;
    
    // Public variables
    public bool gameOver;
   
    public ParticleSystem stardustParticle;
    public ParticleSystem explosionParticle;
    
    public AudioClip foodSound;
    public AudioClip stardustSound;
    public AudioClip explosionSound;
    
    public TextMeshProUGUI scoreText;
    
    public GameObject[] hearts;
    public GameObject gameOverScreen;
    public GameObject cakes;

    public void StartGame()
    {
        // Get player rigidbody, animation, and audio
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponentInChildren<Animator>();
        playerAudio = GetComponent<AudioSource>();

        // Setting score text
        scoreText.text = "Score: 0";
        gameOver = false;
    }

    void Update()
    {
        if (!gameOver)
        {
            // Setting bounds
            SetBoundLeft(leftBound);
            SetBoundRight(rightBound);
            SetBoundTop(topBound);
            SetBoundBottom(lowerBound);

            // Getting the user horizontal & vertical input
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Allowing the player to move left and right and forward and backward
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
            transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // If the player is hit by an obstacle
        if (other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("Red Meteor"))
        {
            // Instantiate the explosion particle effect in the obstacle's position & play it
            Destroy(Instantiate(explosionParticle, other.transform.position, other.transform.rotation).gameObject, explosionTime);

            // Play the sound effect as well
            playerAudio.PlayOneShot(explosionSound, volume);

            // If stardust is not active
            if (!stardustActive)
            {
                // Decrease lives
                lives--;

                // If lives is 0, run GameOver method
                if (lives < 0)
                {
                    GameOver();
                }
                else
                {
                    // Stop the spinning coroutine if already spinning so it can start again
                    if (spinning)
                    {
                        StopCoroutine(SpinPlayerRoutine());
                    }

                    // Start the spinning coroutine
                    StartCoroutine(SpinPlayerRoutine());

                    // Remove a heart from the UI
                    hearts[lives].SetActive(false);
                }
            }
            // If stardust is active and we run into a red meteor
            else if (other.gameObject.CompareTag("Red Meteor"))
            {
                // Check to make sure we have less than 3 lives
                if (lives < 3)
                {
                    // If so, reactivate heart on UI
                    hearts[lives].SetActive(true);

                    // If we have any hearts, set the rotation to the same as the one before
                    if (lives > 0) {
                        hearts[lives].transform.rotation = hearts[lives - 1].transform.rotation;
                    }

                    // And increase the number of lives
                    lives++;
                }
            }
            
        }
        // If the player grabs an ingredient
        else if (other.gameObject.CompareTag("Ingredient"))
        {
            // Play the sound effect
            playerAudio.PlayOneShot(foodSound, volume);

            // Increase the score and display it on the UI
            score++;
            scoreText.text = "Score: " + score;
        }
        // If the player grabs stardust
        else if (other.gameObject.CompareTag("Stardust"))
        {
            // If stardust is already active, stop the current coroutine so we can start it again
            if (stardustActive)
            {
                StopCoroutine(StardustCountdownRoutine());
            }

            // Start the couroutine
            StartCoroutine(StardustCountdownRoutine());
        }

        // Always destroy the other object in a collision
        Destroy(other.gameObject);
    }

    IEnumerator ExplosionRoutine(Collider other)
    {
        // Instantiate the explosion particle effect in the obstacle's position & play it
        Instantiate(explosionParticle, other.transform.position, other.transform.rotation);
        explosionParticle.Play();

        // After a couple seconds, destroy the explosion particle
        yield return new WaitForSeconds(explosionTime);
        Destroy(Instantiate(explosionParticle, other.transform.position, other.transform.rotation));
    }

    IEnumerator StardustCountdownRoutine()
    {
        // Set stardust active
        stardustActive = true;

        // Play sound and particle effect
        playerAudio.PlayOneShot(stardustSound, stardustVolume);
        stardustParticle.Play();

        // Wait 4 seconds
        yield return new WaitForSeconds(stardustTime);

        // Deactivate the stardust and particle effect
        stardustActive = false;
        stardustParticle.Stop();
    }

    IEnumerator SpinPlayerRoutine()
    {
        // Set spinning
        spinning = true;

        // Push the player back and activate the flip animation
        playerRb.AddForce(Vector3.left * pushBack, ForceMode.Impulse);
        playerAnim.SetBool("Impact", true);

        // Wait .9 seconds
        yield return new WaitForSeconds(spinTime);

        // Reset velocity, stop flipping, and reset spinning
        playerRb.velocity = Vector3.zero;
        playerAnim.SetBool("Impact", false);
        spinning = false;
    }

    public void GameOver()
    {
        // Start the continuous flipping animation and stop stardust if it's active
        playerAnim.SetBool("Dead", true);
        stardustParticle.Stop();
        
        // Set the game over screen and game over boolean
        gameOverScreen.SetActive(true);
        cakes.SetActive(true);
        gameOver = true;
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
        if (transform.position.y > bound)
        {
            transform.position = new Vector3(transform.position.x, bound, transform.position.z);
        }
    }

    void SetBoundBottom(float bound)
    {
        if (transform.position.y < bound)
        {
            transform.position = new Vector3(transform.position.x, bound, transform.position.z);
        }
    }
}
