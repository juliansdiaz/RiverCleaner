using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Variables
    public static GameManager Instance { get; private set; }
    [SerializeField] GameObject pauseCanvas;
    bool isGamePaused = false;

    void Awake()
    {
        //Check if there isn't any GameManager instance in the runtime and creates a new one
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject); //Prevents AudioManager from being destroyed during runtime
        }
        else
        {
            Destroy(this.gameObject); //Destroys AudioManager GameObject if there's already an instance
        }
    }

    void Start()
    {
        Time.timeScale = 0; //Starts the execution with the game stopped
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the player has pressed the Escape key to pause the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isGamePaused = !isGamePaused; //Defines game as paused
            PauseGame(); //Call PauseGame method
        }
    }

    public void GameOverWin()
    {
        Time.timeScale = 0; //Stops the game
        UIController.ShowWinScreen(); //Display the Win UI screen
    }

    public void GameOverLose()
    {
        Time.timeScale = 0; //Stops the game
        UIController.ShowLoseScreen(); //Display the Lose UI screen
    }

    public void StartGame()
    {
        Time.timeScale = 1; //Resume the game execution
        pauseCanvas.SetActive(false); //Sets the PauseGame UI to inactive
    }

    public void PlayAgain()
    {
        Time.timeScale = 1; //Resume the game execution
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Reloads the game scene
    }

    void PauseGame()
    {
        //Checks whether the game state is paused or not
        if (isGamePaused)
        {
            pauseCanvas.SetActive(true); //Sets the PauseGame UI to active
            Time.timeScale = 0; //Stop the game 
        }
        else if (isGamePaused == false)
        {
            pauseCanvas.SetActive(false); //Sets the PauseGame UI to inactive
            Time.timeScale = 1; //Resume the game execution
        }
    }
}
