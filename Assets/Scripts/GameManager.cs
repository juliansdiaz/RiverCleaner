using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    bool isGamePaused = false;

    void Awake()
    {
        if(Instance == null)
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
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isGamePaused = !isGamePaused;
            PauseGame();
        }
    }

    public void GameOverWin()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("You win!!!");
    }

    public void GameOverLose()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
    }

    void PauseGame()
    {
        if(isGamePaused)
        {
            Time.timeScale = 0;
        }
        else 
        {
            Time.timeScale = 1;
        }
    }
}
