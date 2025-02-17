using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public float powerUpTimer = 20.0f;
    public bool playerHasPowerUp = false;
    [SerializeField] bool isGamePaused;


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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ManagePowerUpTimer();
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

    public void ManagePowerUpTimer()
    {
        if(playerHasPowerUp == true)
        {
            powerUpTimer -= 1.0f * Time.deltaTime;
        }
        else if(playerHasPowerUp == false)
        {
            powerUpTimer = 20.0f;
        }
    }
}
