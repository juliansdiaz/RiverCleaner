using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] GameObject pauseCanvas;
    bool isGamePaused = false;
    public float gameTime;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isGamePaused = !isGamePaused;
            PauseGame();
        }
    }

    public void GameOverWin()
    {
        Time.timeScale = 0;
        UIController.ShowWinScreen();
    }

    public void GameOverLose()
    {
        Time.timeScale = 0;
        UIController.ShowLoseScreen();
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        gameTime += Time.deltaTime;
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void PauseGame()
    {
        if (isGamePaused)
        {
            pauseCanvas.SetActive(true);
            Time.timeScale = 0;
        }
        else if (isGamePaused == false)
        {
            pauseCanvas.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
