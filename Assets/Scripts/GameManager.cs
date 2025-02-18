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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("You win!!!");
    }

    public void GameOverLose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("You Lose...");
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
